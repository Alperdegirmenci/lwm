using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(lwm.Web.Startup))]

namespace lwm.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
