using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhereIsMyMoney.Backend.Startup))]
namespace WhereIsMyMoney.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
