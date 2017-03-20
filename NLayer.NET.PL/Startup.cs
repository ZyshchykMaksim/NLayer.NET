using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NLayer.NET.PL.Startup))]
namespace NLayer.NET.PL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
