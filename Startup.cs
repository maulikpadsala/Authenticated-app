using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PolicyBazar.Startup))]
namespace PolicyBazar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
