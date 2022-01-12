using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupService.HubConfig
{
    public class GroupMessagesHub : Hub
    {
        public async Task AskServer(string message)
        {
            string tempMessage = "The message was ";

            if (message != "hey")
            {
                tempMessage += "something else";
            }
            else
            {
                tempMessage += message;
            }

            await Clients.Clients(this.Context.ConnectionId).SendAsync("askServerResponse", tempMessage);
        }

        public Task JoinGroup(string groupName)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public Task LeaveGroup(string groupName)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task SendMessageToGroup(string groupId, string message)
        {
            await Clients.Group(groupId).SendAsync("groupsMessage", message);
        }
    }
}
