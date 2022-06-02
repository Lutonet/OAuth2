namespace OAuth2DataAccess.Models
{
    public class UserLoginsModel
    {
        public int Id { get; set; }
        public string LoginProvide { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}