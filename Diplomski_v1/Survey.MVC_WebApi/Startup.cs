using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Survey.MVC_WebApi.Startup))]
namespace Survey.MVC_WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
