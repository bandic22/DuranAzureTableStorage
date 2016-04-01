using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DuranAssignmentBluePython.Startup))]
namespace DuranAssignmentBluePython
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
