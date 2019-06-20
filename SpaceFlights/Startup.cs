using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SpaceFlights.Startup))]
namespace SpaceFlights
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
