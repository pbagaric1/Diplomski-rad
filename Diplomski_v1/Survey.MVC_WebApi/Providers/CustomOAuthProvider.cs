using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Survey.MVC_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Survey.MVC_WebApi.Providers
{
    public class CustomOAuthProvider : OAuthAuthorizationServerProvider
    {

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            var allowedOrigin = "*";

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            var userManager = context.OwinContext.GetUserManager<ApplicationUserManager>();

            ApplicationUser user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");         

            //add user to token
            var props = new AuthenticationProperties(new Dictionary<string, string>
            {
                {  "username", context.UserName },
                {  "userId", user.Id }
            });

            var ticket = new AuthenticationTicket(oAuthIdentity, props);

            context.Validated(ticket);

            //check if admin or normal user
            //var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            //if (context.UserName == "admin")
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            //    identity.AddClaim(new Claim("username", "admin"));
            //}
            //else
            //{
            //    identity.AddClaim(new Claim("sub", context.UserName));
            //    identity.AddClaim(new Claim("role", "user"));
            //}

            //add username to token
            //var props = new AuthenticationProperties(new Dictionary<string, string>
            //{
            //    {  "username", context.UserName }
            //});

            //var ticket = new AuthenticationTicket(identity, props);
            //context.Validated(ticket);

            //if (!user.EmailConfirmed)
            //{
            //    context.SetError("invalid_grant", "User did not confirm email.");
            //    return;
            //}

            //ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, "JWT");

            //var ticket = new AuthenticationTicket(oAuthIdentity, null);

            //context.Validated(ticket);

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }
            return Task.FromResult<object>(null);
        }
    }
}