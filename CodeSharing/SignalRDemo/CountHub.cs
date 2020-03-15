using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Serivces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo
{
    //[Authorize]
    public class CountHub:Hub
    {
        private readonly CountServices _countServices;
        public CountHub(CountServices countServices)
        {
            _countServices = countServices;
        }
        public async Task GetLatestCount(string random)
        {
            //var user = Context.User.Identity.Name;
            int count;
            do
            {
                count = _countServices.GetLatestCount();
                Thread.Sleep(1000);
                await Clients.All.SendAsync("ReceiveUpdate", count);
            }
            while (count < 10);
            await Clients.All.SendAsync("Finished");
        }

        public override async Task OnConnectedAsync()
        {
            // 获取客户端id
            //var connectionId = Context.ConnectionId;
            //var client = Clients.Clients(connectionId);
            //await client.SendAsync("someFunc", new { });
        }
    }
}
