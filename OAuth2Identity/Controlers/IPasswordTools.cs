namespace OAuth2Identity.Controlers
{
    public interface IPasswordTools
    {
        string HashPassword(string password, byte[] salt = null, bool needsOnlyHash = false);
        bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck);
    }
}