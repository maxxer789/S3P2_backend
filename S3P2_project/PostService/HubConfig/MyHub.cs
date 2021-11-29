using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.HubConfig
{
    public class MyHub : Hub
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

        public async Task SendMessage(string message)
        {
            string tempMessage = "The message was: " + message;

            await Clients.Clients(this.Context.ConnectionId).SendAsync("messageRespone", message);
        }
    }
}
