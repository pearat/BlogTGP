using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogTGP.Startup))]
namespace BlogTGP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
