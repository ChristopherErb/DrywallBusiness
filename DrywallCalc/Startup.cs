using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrywallCalc.Startup))]
namespace DrywallCalc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
