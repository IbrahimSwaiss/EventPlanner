using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventPlanner.Site.Startup))]
namespace EventPlanner.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
