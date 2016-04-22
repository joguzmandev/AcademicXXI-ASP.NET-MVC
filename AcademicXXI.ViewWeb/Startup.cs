using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AcademicXXI.ViewWeb.Startup))]
namespace AcademicXXI.ViewWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
