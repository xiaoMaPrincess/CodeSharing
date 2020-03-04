using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public interface IOrderServices
    {
        int ShowMaxOrderCount();
    }
    /// <summary>
    /// 选项
    /// </summary>
    public class OrderServices : IOrderServices
    {
        //readonly IOptions<OrderServicesOptions> servicesOptions;
        // IOptionsSnapshot 数据热更新，感知配置的数据变化，适用于范围内单例
        readonly IOptionsSnapshot<OrderServicesOptions> servicesOptions;
        public OrderServices(IOptionsSnapshot<OrderServicesOptions> _servicesOptions)
        {
            servicesOptions = _servicesOptions;
        }
        public int ShowMaxOrderCount()
        {
            return servicesOptions.Value.MaxOrderCount;
        }
    }
    public class OrderServicesOptions
    {
        public int MaxOrderCount { get; set; } = 100;
    }
}
