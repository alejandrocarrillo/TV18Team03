using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TallerVertical18.Startup))]
namespace TallerVertical18
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
