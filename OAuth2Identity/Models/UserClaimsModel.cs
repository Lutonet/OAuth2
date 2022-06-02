namespace OAuth2Identity.Models
{
    public class UserClaimsModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}