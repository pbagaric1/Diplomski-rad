﻿using Survey.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model
{
    public class AspNetUserLoginDomain : IAspNetUserLoginDomain
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserId { get; set; }

        public virtual IAspNetUserDomain AspNetUser { get; set; }
    }
}
