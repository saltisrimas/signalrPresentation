using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;

namespace WebApplication
{
    
    public class ChatHub_1 : Hub
    {
        public void SendMessage(string message)
        {            
            base.Clients.addMessage(message);            
        }
        
    }
}