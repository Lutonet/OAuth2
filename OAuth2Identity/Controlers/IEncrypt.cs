namespace OAuth2Identity.Controlers
{
    public interface IEncrypt
    {
        string DecryptString(string cipherText);

        string EncryptString(string plainText);
    }
}