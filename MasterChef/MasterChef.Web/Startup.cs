using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterChef.Web.Startup))]
namespace MasterChef.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
