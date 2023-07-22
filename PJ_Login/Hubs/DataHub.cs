using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PJ_Login.Hubs
{
    public class DataHub:Hub
    {
        public async Task SendUpdate(string data)
        {
            await Clients.All.SendAsync("UpdateData", data);
        }
    }
}
