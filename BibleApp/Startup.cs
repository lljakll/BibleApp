using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BibleApp.Startup))]
namespace BibleApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
