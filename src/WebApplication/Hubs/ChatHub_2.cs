using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;

namespace WebApplication
{
    
    public class ChatHub_2 : Hub
    {

        public class MessageData { 
            public string UserName { get; set; } 
            public string Message { get; set; } 
        }

        public void SendMessage(MessageData message)
        {
            base.Clients.addMessage(message);
        }
        
    }
}