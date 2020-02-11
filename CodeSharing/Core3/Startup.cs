using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core3
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        public Startup()
        {
            Console.WriteLine("StartUp");
        }
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine("StartUpConfigureServices");
            services.AddRouting().AddControllersWithViews();
        }

        /// <summary>
        /// 注册中间件
        /// </summary>
        /// <param name="app"></param>
        public void Configure(IApplicationBuilder app)
        {
            Console.WriteLine("StartUpConfigure");
            app.UseRouting().UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
