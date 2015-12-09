using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyHybridSite.Startup))]
namespace MyHybridSite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
