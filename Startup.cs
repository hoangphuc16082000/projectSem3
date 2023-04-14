using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExcelOnServices.Startup))]
namespace ExcelOnServices
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
