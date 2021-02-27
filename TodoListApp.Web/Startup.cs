using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TodoListApp.Web.Startup))]
namespace TodoListApp.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
