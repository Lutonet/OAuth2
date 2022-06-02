namespace OAuth2Identity.Models
{
    internal class EncryptionSettings
    {
        public bool UseEncryption { get; }
        public string InitVector { get; }
        public string Passphrase { get; }
    }
}