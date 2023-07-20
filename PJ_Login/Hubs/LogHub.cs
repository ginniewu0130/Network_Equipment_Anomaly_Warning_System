using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace PJ_Login.Hubs
{
    public class LogHub:Hub
    {
        public async Task SendLogUpdate()
        {
            // 發送訊息給前端，通知有新的資料需要更新
            await Clients.All.SendAsync("ReceiveLogUpdate");
        }
    }
}
