using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Core3
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Core3.0 启动方式演示
            // 自定义主机
            Host.CreateDefaultBuilder()
               .ConfigureWebHost(webHostBuilder => webHostBuilder
                   .UseKestrel()
                   .UseUrls("https://localhost:5001/")
                   .ConfigureServices(x => Console.WriteLine("ConfigureWebHost"))
                   .Configure(app => app.Run(
                        context => context.Response.WriteAsync("Configure"))))
               .ConfigureHostConfiguration(x=> { Console.WriteLine("ConfigureHostConfiguration"); })
               .ConfigureAppConfiguration(x => { Console.WriteLine("ConfigureAppConfiguration"); })
               .ConfigureServices(x=> { Console.WriteLine("ConfigureServices"); })
               .Build()
               .Run();

            //host.createdefaultbuilder()
            //  .configurewebhostdefaults(webhostbuilder => webhostbuilder
            //      .configureservices(servicecs => servicecs
            //          .addrouting() // 添加路由与控制器视图的服务
            //          .addcontrollerswithviews())
            //      .configure(app => app
            //          .userouting() //注册路由中间并添加映射
            //          .useendpoints(endpoints => endpoints.mapcontrollers())))
            //  .build()
            //  .run();

            // Host.CreateDefaultBuilder()
            //.ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>())
            //.Build()
            //.Run();
            #endregion

            //CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(builder => { Console.WriteLine("ConfigureAppConfiguration"); })
            .ConfigureServices(service => { Console.WriteLine("ConfigureServices"); })
            .ConfigureHostConfiguration(builder => { Console.WriteLine("ConfigureHostConfiguration"); })
          .ConfigureWebHostDefaults(webBuilder =>
          {
              Console.WriteLine("ConfigureWebHostDefaults");
              webBuilder.UseStartup<Startup>();
          });
    }
}
