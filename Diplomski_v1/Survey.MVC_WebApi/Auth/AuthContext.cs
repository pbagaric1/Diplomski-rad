using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Survey.MVC_WebApi.Auth
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("SurveyConnString")
        {

        }

        public static AuthContext Create()
        {
            return new AuthContext();
        }
    }
}