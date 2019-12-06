using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WondermazingGameStore.Web.Startup))]
namespace WondermazingGameStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
