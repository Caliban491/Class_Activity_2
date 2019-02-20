using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prac_2_ASP_MVC.Startup))]
namespace Prac_2_ASP_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
