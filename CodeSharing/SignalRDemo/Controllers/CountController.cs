using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRDemo.Controllers
{
    [Route("api/count")]
    public class CountController : Controller
    {
        private readonly IHubContext<CountHub> _hubContext;
        public CountController(IHubContext<CountHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task<IActionResult> Post()
        {
            await _hubContext.Clients.All.SendAsync("someFunc", new { random = "Hello word!" });
            return Accepted(1);
        }
    }
}