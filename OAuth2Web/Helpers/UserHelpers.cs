using OAuth2Web.Models;

namespace OAuth2Web.Helpers
{
    public class UserHelpers : IUserHelpers
    {
        public UserHelpers()
        {
            Helpers.Add(AdminHelp);
        }

        public List<HelperModel> Helpers = new List<HelperModel>();

        public HelperModel GetHelp(string name)
        {
            return Helpers.FirstOrDefault(x => x.Name == name);
        }

        private HelperModel AdminHelp = new HelperModel()
        {
            Name = "CreateSystemAdmin",
            Header = "CreateSystemAdminHeader",
            BodyText = "CreateSystemAdminBodyText"
        };
    }
}