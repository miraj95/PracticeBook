using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PracticeBook.Startup))]
namespace PracticeBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
