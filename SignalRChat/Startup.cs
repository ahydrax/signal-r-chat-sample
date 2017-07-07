using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using SignalRChat;

[assembly: OwinStartup(typeof(Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfig = new HubConfiguration
            {
                EnableJavaScriptProxies = false,
                EnableDetailedErrors = true
            };

            var httpConfig = new HttpConfiguration
            {
                
            };
            httpConfig.MapHttpAttributeRoutes();
            app.UseWebApi(httpConfig);
            app.MapSignalR(@"/signalr", hubConfig);
        }
    }
}
