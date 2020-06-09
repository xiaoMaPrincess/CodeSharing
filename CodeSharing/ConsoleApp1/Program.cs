using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region v1.0
            //Host.CreateDefaultBuilder()
            //    // 构建请求管道
            //    .ConfigureWebHost(webHostBuilder => webHostBuilder
            //    // 注册服务器
            //    .UseKestrel()
            //    // 注册中间件
            //    .Configure(app => app.Run(context => context.Response.WriteAsync("hi"))))
            //    // 构建IHost
            //    .Build()
            //    // 启动应用程序
            //    .Run();
            #endregion

            #region 默认时
            //Host.CreateDefaultBuilder()
            //    // 构建请求管道
            //    .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder
            //    // 注册服务器
            //    .UseKestrel()
            //    // 注册中间件
            //    .Configure(app => app.Run(context => context.Response.WriteAsync("hi"))))
            //    // 构建IHost
            //    .Build()
            //    // 启动应用程序
            //    .Run();
            #endregion
            Host.CreateDefaultBuilder()
                // 构建请求管道
                .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder
                // 注册路由和控制器视图服务(路由中间件依赖这两个服务)
                .ConfigureServices(x => x.AddRouting().AddControllersWithViews())
                // 注册路由与中间点映射中间件
                .Configure(app => app.UseRouting().UseEndpoints(x => x.MapControllers())))
                // 构建IHost
                .Build()
                // 启动应用程序
                .Run();
            #region MVC

            #endregion
        }
    }
}
