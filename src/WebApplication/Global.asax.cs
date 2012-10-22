using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using SignalR;
using SignalR.Redis;
namespace WebApplication
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapConnection<ChatConnection>("chat", "chat/{*operation}");
            GlobalHost.DependencyResolver.Register(typeof(IConnectionIdGenerator), () => { return new ConnectionIdGenerator(); });
            
        }

        
    }
}