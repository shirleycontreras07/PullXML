using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PullXml.Startup))]
namespace PullXml
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
