using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Menu_x_Me_App.Startup))]
namespace Menu_x_Me_App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
