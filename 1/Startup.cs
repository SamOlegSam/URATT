using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UchetAuto.Startup))]
namespace UchetAuto
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
