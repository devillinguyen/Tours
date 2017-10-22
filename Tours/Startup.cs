using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tours.Startup))]
namespace Tours
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
