using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2Identity.Services
{
    public class TokenService
    {
        public TokenService()
        {
        }

        public string GenerateToken(string userId, string applicationId)
        {
            return $"{userId} {applicationId}";
        }

        public string GenerateRefreshToken()
        {
            return $"{Guid.NewGuid()}";
        }
    }
}