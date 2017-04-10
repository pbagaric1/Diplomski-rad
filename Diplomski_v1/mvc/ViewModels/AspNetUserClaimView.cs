using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.MVC_WebApi.ViewModels
{
    public class AspNetUserClaimView
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public virtual AspNetUserView AspNetUser { get; set; }
    }
}