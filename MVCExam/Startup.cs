using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCExam.Startup))]
namespace MVCExam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
