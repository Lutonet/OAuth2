namespace OAuth2Identity.Models
{
    public class IdentityUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
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
        public DateTime AccountCreated { get; set; }
        public DateTime AccountLocked { get; set; }
        public string LockedReason { get; set; }
        public string LockedByAdminId { get; set; }
    }
}