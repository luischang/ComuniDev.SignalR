using Microsoft.AspNetCore.SignalR;

namespace ComuniDev.SignalR.API.RealTime
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
