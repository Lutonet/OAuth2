using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Models
{
    public class Response
    {
        public bool Successfull { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}