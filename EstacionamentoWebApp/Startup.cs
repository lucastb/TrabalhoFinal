using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EstacionamentoWebApp.Startup))]
namespace EstacionamentoWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
