using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class ServerAdminRegistrationModel
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public bool PasswordConfirmed { get; set; } = true;
        public string PasswordHash { get; set; }
        public string FirstName { get; set; } = "Server";
        public string LastName { get; set; } = "Administrator";
        public string PublicName { get; set; } = "Lord of the server";
        public bool IsDeveloper { get; set; } = true;
        public string Name { get; set; } = "Authenticator";
        public string Description { get; set; } = "Authenticator application";
        public bool IsActive { get; set; } = true;
    }
}