namespace OAuth2DataAccess.Models
{
    public class UserPublicModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public bool LockoutEnabled { get; set; }
        public DateTime LockoutEndDateUtc { get; set; }
        public int AccessFailedCount { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PublicName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsDeveloper { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string Microsoft { get; set; }
        public string Google { get; set; }
        public string WebPage { get; set; }
        public DateTime Timestamp { get; set; }
        public DateTime AccountCreated { get; set; }
        public DateTime AccountLocked { get; set; }
        public string LockedReason { get; set; }
        public string LockedByAdminId { get; set; }
        public List<string> Roles { get; set; } = new List<string>();
    }
}