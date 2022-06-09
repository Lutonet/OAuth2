using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Mailer.Model
{
    public class SMTPSettings
    {
        public SMTPSettings()
        {
            Security = SecureSocketOptions.Auto;
        }

        public string ServerAddress { get; set; } = "";
        public int ServerPort { get; set; } = 0;
        public bool RequiresAuthentication { get; set; } = false;
        public SecureSocketOptions Security { get; set; } = SecureSocketOptions.Auto;
        public string EmailUser { get; set; } = "";
        public string Password { get; set; } = "";
    }
}