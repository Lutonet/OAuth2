namespace OAuth2Identity
{
    public class IdentityConfiguration
    {
        public bool UseEmailConfirmation { get; set; } = false;
        public bool UsePhoneConfirmation { get; set; } = false;
        public bool UsePasswordRules { get; set; } = true;
        public PasswordRules PasswordRules { get; set; } = new();
        public ConfirmationCode CodeRules { get; set; } = new();
    }

    public class PasswordRules
    {
        public int MinimalLength { get; set; } = 8;
        public bool MustIncludeSmall { get; set; } = true;
        public bool IncludeCapital { get; set; } = true;
        public bool IncludeNumber { get; set; } = true;
        public bool IncludeSpecialCharacter { get; set; } = false;
    }

    public class ConfirmationCode
    {
        public int Length { get; set; } = 6;
        public int CodeValidMinutes { get; set; } = 15;
    }
}