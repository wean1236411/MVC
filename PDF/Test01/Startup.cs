using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test01.Startup))]
namespace Test01
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
