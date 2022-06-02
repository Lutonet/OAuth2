using Microsoft.Extensions.Configuration;
using OAuth2Identity.Models;
using System.Security.Cryptography;
using System.Text;

namespace OAuth2Identity.Controlers
{
    public class Encrypt : IEncrypt
    {
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "pemgail9uzpgzl88";

        // This constant is used to determine the keysize of the encryption algorithm
        private const int keysize = 256;

        private readonly IConfiguration _configuration;
        private readonly string _initVector;
        private readonly string _passphrase;
        private readonly bool _useEncryption;

        public Encrypt(IConfiguration configuration)
        {
            _configuration=configuration;
            EncryptionSettings settings = (EncryptionSettings)configuration.GetSection("Encryption");
            if (settings == null)
            {
                _useEncryption = false;
            }
            else
            {
                _useEncryption = settings.UseEncryption;
                _initVector = settings.InitVector;
                _passphrase = settings.Passphrase;
            }
        }

        //Encrypt
        public string EncryptString(string plainText)
        {
            if (!_useEncryption) return plainText;

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(_initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(_passphrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        //Decrypt
        public string DecryptString(string cipherText)
        {
            if (!_useEncryption) return cipherText;

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(_initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(_passphrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}