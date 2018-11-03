using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Netflix.Startup))]
namespace Netflix
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
