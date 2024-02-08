using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetAuthentication.Startup))]
namespace AspNetAuthentication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
