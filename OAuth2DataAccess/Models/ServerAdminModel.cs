using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class ServerAdminModel
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; } = "Server";
        public string LastName { get; set; } = "Administrator";
        public string PublicName { get; set; } = "Lord of the server";
        public bool IsDeveloper { get; set; } = true;

        // Application Table
        public string Name { get; set; } = "Authenticator";

        public string ApplicationKey { get; set; }

        public string Description { get; set; } = "Authenticator application";
        public bool IsActive { get; set; } = true;
    }
}