using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FilExplorer.Startup))]
namespace FilExplorer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
