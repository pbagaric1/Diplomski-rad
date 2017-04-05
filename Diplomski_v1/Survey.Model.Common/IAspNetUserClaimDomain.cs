﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Model.Common
{
    public interface IAspNetUserClaimDomain
    {
        string Id { get; set; }
        string UserId { get; set; }
        string ClaimType { get; set; }
        string ClaimValue { get; set; }

        IAspNetUserDomain AspNetUser { get; set; }
    }
}
