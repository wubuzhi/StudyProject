﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.Server.Token
{
    public class Token
    {
        public string TokenContent { get; set; }

        public DateTime Expires { get; set; }
    }

    public class ComplexToken
    {
        public Token AccessToken { get; set; }
        public Token RefreshToken { get; set; }
    }
}
