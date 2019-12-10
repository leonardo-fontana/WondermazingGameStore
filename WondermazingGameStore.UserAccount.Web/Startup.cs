using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WondermazingGameStore.UserAccount.Web.Startup))]
namespace WondermazingGameStore.UserAccount.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
