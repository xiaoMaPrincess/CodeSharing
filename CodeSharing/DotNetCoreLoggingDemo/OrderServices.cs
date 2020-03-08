using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCoreLoggingDemo
{
    public class OrderServices
    {
         ILogger<OrderServices> logger;
        public OrderServices(ILogger<OrderServices> _logger)
        {
            logger = _logger;
        }
        public void Show()
        {
            logger.LogInformation("Show{time}", DateTime.Now);
            logger.LogInformation($"Show{DateTime.Now}"); //消耗资源
        }
        
    }
}
