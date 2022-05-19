using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ApplicationId { get; set; }
    }
}