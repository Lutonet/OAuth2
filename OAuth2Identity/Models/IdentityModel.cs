namespace OAuth2Identity.Models
{
    public class IdentityModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public bool ReturnUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
    }
}