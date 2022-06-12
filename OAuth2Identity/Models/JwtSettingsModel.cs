using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Models
{
    public class JwtSettingsModel
    {
        public int TokenExpiresInMinutes { get; set; } = 60;
        public int RefreshTokenExpiresInDays { get; set; } = 30;
    }
}