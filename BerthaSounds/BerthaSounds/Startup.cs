using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BerthaSounds.Startup))]
namespace BerthaSounds
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
