using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspNetPractice.Startup))]
namespace AspNetPractice
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
