namespace OAuth2DataAccess.Models
{
    public class UserClaimModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public DateTime Timestamp { get; set; }
    }
}