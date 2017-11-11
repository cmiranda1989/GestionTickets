using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionTickets.Backend.Startup))]
namespace GestionTickets.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
