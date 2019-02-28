using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace lwm.Web.Hub
{
    public class MapHub : Microsoft.AspNet.SignalR.Hub
    {
        public async Task Send(string username, string message)
        {
            SendNotifications(message);
            await Clients.All.SendAsync(username, message);
        }

        public void SendNotifications(string message)
        {
            Clients.All.receiveNotification(message);
        }

    }
}