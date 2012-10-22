using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication
{
    public class ConnectionIdGenerator : SignalR.IConnectionIdGenerator
    {
        public string GenerateConnectionId(SignalR.IRequest request)
        {
            if (request.Cookies["connectionId"] != null)
            {                
                return request.Cookies["connectionId"].Value;
            }

            else 
                return Guid.NewGuid().ToString();
        }
    }
}