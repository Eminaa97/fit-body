using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitBody.Api.Hubs
{
    public class NotificationHub : Hub
    {
        public static Dictionary<string, string> clients = new Dictionary<string, string>();

        public override Task OnConnectedAsync()
        {
            lock (clients)
                if (!clients.ContainsKey(Context.ConnectionId))
                    clients.Add(Context.ConnectionId, Context.UserIdentifier);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            lock (clients)
                if (clients.ContainsKey(Context.ConnectionId))
                    clients.Remove(Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
