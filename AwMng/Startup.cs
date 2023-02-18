using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AwMng.Startup))]
namespace AwMng
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
