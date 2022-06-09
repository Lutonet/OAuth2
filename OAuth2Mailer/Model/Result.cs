using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Mailer.Model
{
    public class Result
    {
        public bool Successfull { get; set; } = true;
        public string Message { get; set; } = "";
    }
}