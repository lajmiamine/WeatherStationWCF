using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace WeatherStation.Models
{
    public class MesureHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MesureHub>();
            context.Clients.All.displayStatus();
        }
    }

    public class NotifHub : Hub
    {
        public static void Show()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotifHub>();
            context.Clients.All.displayStatus();
        }
    }
}