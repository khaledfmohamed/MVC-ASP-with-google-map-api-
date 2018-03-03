using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Events.View.Startup))]
namespace Events.View
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
