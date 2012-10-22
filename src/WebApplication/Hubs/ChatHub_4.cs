using SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Timers;

namespace WebApplication
{    
    public class ChatHub_4 : Hub, IConnected, IDisconnect
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

        

        public System.Threading.Tasks.Task Connect()
        {
            return Clients.addLog(string.Format("Client '{0}' connected.", Context.ConnectionId));
        }

        public System.Threading.Tasks.Task Reconnect(IEnumerable<string> groups)
        {
            return Clients.addLog(string.Format("Client '{0}' reconnected .", Context.ConnectionId));
        }

        public System.Threading.Tasks.Task Disconnect()
        {
            return Clients.addLog(string.Format("Client '{0}' disconnected.", Context.ConnectionId));
        }
    }
}