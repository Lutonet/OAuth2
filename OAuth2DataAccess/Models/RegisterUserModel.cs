using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class RegisterUserModel
    {
        public string Id { get; set; } = new Guid().ToString();
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PublicName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}