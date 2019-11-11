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
            //Host.CreateDefaultBuilder()
            //   .ConfigureWebHost(webHostBuilder => webHostBuilder
            //       .UseKestrel()
            //       .UseUrls("https://localhost:5001/")
            //       .Configure(app => app.Run(
            //            context => context.Response.WriteAsync("Hello World."))))
            //   .Build()
            //   .Run();

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

            Host.CreateDefaultBuilder()
           .ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.UseStartup<Startup>())
           .Build()
           .Run();


   //         < Project Sdk = "Microsoft.NET.Sdk" >
 
   //< PropertyGroup >
 
   //  < OutputType > Exe </ OutputType >
 
   //  < TargetFramework > netcoreapp3.0 </ TargetFramework >
    
   //   </ PropertyGroup >
   // </ Project >
        }
    }
}
