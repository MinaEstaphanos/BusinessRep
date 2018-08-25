using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessRep.Startup))]
namespace BusinessRep
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
