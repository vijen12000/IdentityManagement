﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI._1._0.Models
{
    public class PasswordResetModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }
}