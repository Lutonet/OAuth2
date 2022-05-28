using OAuth2Web.Models;

namespace OAuth2Web.Helpers
{
    internal class UserHelpers
    {
        public static List<HelperModel> Helpers = new List<HelperModel>();

        private HelperModel AdminHelp = new HelperModel()
        {
            Name = "CreateSystemAdmin",
            Header = "CreateSystemAdminHeader",
            BodyText = "CreateSystemAdminBodyText"
        };
    }
}