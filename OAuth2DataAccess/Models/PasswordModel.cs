using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class PasswordModel
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}