﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.Models
{
    public class LoginResponseModel
    {
        public bool Success { get; set; } = true;
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string Error { get; set; }
    }
}