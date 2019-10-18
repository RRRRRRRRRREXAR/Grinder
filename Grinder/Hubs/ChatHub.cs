using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grinder.Hubs
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ChatHub:Hub
    {
        public async Task Send(string message,string to)
        {
            var userName = Context.User.Identity.Name;
            if (Context.UserIdentifier!=to)
            {
                await Clients.User(Context.UserIdentifier).SendAsync("Recieve",message,userName);
            }
            await Clients.User(to).SendAsync("Recieve",message,userName);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Приветствуем {Context.UserIdentifier}");
            await base.OnConnectedAsync();
        }
    }
}
