using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAtSmartVideo.Startup))]
namespace WebAtSmartVideo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
