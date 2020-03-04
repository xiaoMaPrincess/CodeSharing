using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptionsDemo.Services
{
    public static class OrderServicesExtensions
    {
        /// <summary>
        /// 在扩展方法注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddOrderServices(this IServiceCollection services,IConfiguration configuration)
        {

            #region 配置验证

            services.AddOptions<OrderServicesOptions>().Configure(x =>
            {
                configuration.Bind(x);
            }).Validate(x =>
            {
                return x.MaxOrderCount < 100;
            },"配置错误");// 配置验证
            #endregion

            #region 动态配置
            services.Configure<OrderServicesOptions>(configuration);
            // 动态配置
            services.PostConfigure<OrderServicesOptions>(options => {
                options.MaxOrderCount += 100;
            });
            #endregion

            services.AddScoped<IOrderServices, OrderServices>();
            return services;
        }
    }
}
