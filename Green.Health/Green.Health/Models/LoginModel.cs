﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Green.Health.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }

        public string Pwd { get; set; }

        public bool RememberMe { get; set; }

    }
}