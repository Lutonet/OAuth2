using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Models
{
    public class RegisterModel
    {
        [JsonProperty("email")]
        private string Email { get; set; }

        [JsonProperty("password")]
        private string Password { get; set; }

        [JsonProperty("publicName")]
        private string PublicName { get; set; }

        private string FirstName { get; set; }
        private string LastName { get; set; }
    }
}