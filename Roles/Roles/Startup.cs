using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Roles.Startup))]
namespace Roles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
