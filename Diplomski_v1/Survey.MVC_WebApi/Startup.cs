using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Survey.MVC_WebApi.Models;
using Survey.MVC_WebApi.Providers;
using System;
using System.Configuration;
using System.Web.Http;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Survey.MVC_WebApi.App_Start;

[assembly: OwinStartup(typeof(Survey.MVC_WebApi.Startup))]
namespace Survey.MVC_WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ConfigureOAuthTokenGeneration(app);
            ConfigureOAuthTokenConsumption(app);
        }

        //public void ConfigureOAuth(IAppBuilder app)
        //{
        //    OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
        //    {
        //        AllowInsecureHttp = true,
        //        TokenEndpointPath = new PathString("/api/token"),
        //        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        //        Provider = new SimpleAuthorizationServerProvider()
        //    };

        //    // Token Generation
        //    app.UseOAuthAuthorizationServer(OAuthServerOptions);
        //    app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

        //}

        private void ConfigureOAuthTokenGeneration(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {

                //For Dev enviroment only (on production should be AllowInsecureHttp = false)
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/api/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new CustomOAuthProvider(),
                AccessTokenFormat = new CustomJwtFormat("http://localhost:52797")
            };

            // OAuth 2.0 Bearer Access Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
        }

        private void ConfigureOAuthTokenConsumption(IAppBuilder app)
        {

            var issuer = "http://localhost:52797";
            string audienceId = ConfigurationManager.AppSettings["as:AudienceId"];
            byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["as:AudienceSecret"]);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { audienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
                    }
                });
        }

        //private void createRoles()
        //{
        //    ApplicationDbContext context = new ApplicationDbContext();

        //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
        //    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


        //    // In Startup iam creating first Admin Role and creating a default Admin User    
        //    //if (!roleManager.RoleExists("Admin"))
        //    //{

        //    //    // first we create Admin rool   
        //    //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //    //    role.Name = "Admin";
        //    //    roleManager.Create(role);

        //    //    //Here we create a Admin super user who will maintain the website                  

        //    //    var user = new ApplicationUser();
        //    //    user.UserName = "pbagaric1@gmail.com";
        //    //    user.Email = "pbagaric1@gmail.com";

        //    //    string userPWD = "asdasd1";

        //    //    var chkUser = UserManager.Create(user, userPWD);

        //    //    //Add default User to Role Admin   
        //    //    if (chkUser.Succeeded)
        //    //    {
        //    //        var result1 = UserManager.AddToRole(user.Id, "Admin");

        //    //    }
        //    //}

        //    //// creating Creating Manager role    
        //    //if (!roleManager.RoleExists("Manager"))
        //    //{
        //    //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        //    //    role.Name = "Manager";
        //    //    roleManager.Create(role);

        //    //}
        //}
    }


}
