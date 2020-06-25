using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventPlanner.CMS.Startup))]
namespace EventPlanner.CMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
