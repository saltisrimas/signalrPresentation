using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;

namespace WebApplication
{    
    public class ChatHub_3 : Hub
    {

        public class MessageData { 
            public string UserName { get; set; } 
            public string Message { get; set; } 
        }

        public void SendMessage(MessageData message)
        {
            if (string.IsNullOrEmpty(message.UserName))
                throw new NotSupportedException("User name can not be empty.");
            if (string.IsNullOrEmpty(message.Message))
                throw new NotSupportedException("Message can not be empty.");
            base.Clients.addMessage(message);
        }
        
    }
}