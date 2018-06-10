using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoogleOAuth.Startup))]
namespace GoogleOAuth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
