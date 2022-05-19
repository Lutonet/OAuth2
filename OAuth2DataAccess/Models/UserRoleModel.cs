using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class UserRoleModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int RoleId { get; set; }
    }
}