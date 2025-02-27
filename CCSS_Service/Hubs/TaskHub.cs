using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSS_Service.Hubs
{
    public class TaskHub : Hub
    {
        private static readonly ConcurrentDictionary<string, string> _userConnections = new();

        public override Task OnConnectedAsync()
        {
            string accountId = Context.UserIdentifier; 
            if (!string.IsNullOrEmpty(accountId))
            {
                _userConnections[accountId] = Context.ConnectionId; // Lưu AccountId với ConnectionId
            }
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string accountId = Context.UserIdentifier;
            if (!string.IsNullOrEmpty(accountId))
            {
                _userConnections.TryRemove(accountId, out _);
            }
            return base.OnDisconnectedAsync(exception);
        }

        // Lấy ConnectionId từ AccountId
        public static string GetConnectionId(string accountId)
        {
            return _userConnections.TryGetValue(accountId, out string connectionId) ? connectionId : null;
        }
    }
}
