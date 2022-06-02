namespace OAuth2DataAccess.Models
{
    public class ApplicationModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public string HomeUrl { get; set; }
        public DateTime LockedUntil { get; set; }
        public string LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
        public string TermsUrl { get; set; }
        public string ReturnUrl { get; set; }
        public bool HasUserAgeLimits { get; set; }
        public int AgeFrom { get; set; }
    }
}