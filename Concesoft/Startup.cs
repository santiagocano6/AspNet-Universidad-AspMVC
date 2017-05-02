using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Concesoft.Startup))]
namespace Concesoft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
