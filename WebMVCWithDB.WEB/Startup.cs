using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebMVCWithDB.WEB.Startup))]
namespace WebMVCWithDB.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
