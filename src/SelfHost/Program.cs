using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR;
using SignalR.Hosting.Self;
using SignalR.Infrastructure;

namespace SelfHost
{
    
    class Program
    {        
        static void Main(string[] args)
        {
            var url = "http://localhost:17/";
            var server = new Server(url);
            /// need this line when hosting signalR from another dll
            server.ConnectionManager.GetHubContext<WebApplication.ChatHub_4>();
            server.MapHubs();
            server.Start();
            Console.WriteLine(string.Format("signalr running on: {0}", url));


            var timer = new System.Timers.Timer(5000);
            timer.Elapsed += (o, e) =>
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<WebApplication.ChatHub_4>();
                Console.WriteLine("ping back from self host");
                context.Clients.addLog("ping back from self host");
            };
            timer.Start();
            
            Console.ReadLine();
        }
        
    }
}
