using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LaraAbdallah_Homework3.Startup))]
namespace LaraAbdallah_Homework3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
