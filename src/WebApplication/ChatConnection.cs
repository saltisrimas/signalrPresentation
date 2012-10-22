using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class ChatConnection : SignalR.PersistentConnection
    {
        
        protected override System.Threading.Tasks.Task OnReceivedAsync(
            SignalR.IRequest request, 
            string connectionId, 
            string data)
        {
            
            return base.Connection.Broadcast(data);
        }
    }
}