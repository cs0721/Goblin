using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment_Di.Startup))]
namespace Assignment_Di
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
