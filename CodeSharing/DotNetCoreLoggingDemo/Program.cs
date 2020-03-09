using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace DotNetCoreLoggingDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            LoggingScope();

            #region 配置
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var config = configurationBuilder.Build();
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(p => config);//使用工厂模式注入
            #endregion
            #region logging
            // 注册服务
            serviceCollection.AddLogging(builder =>
            {
                // 日志配置
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();// 控制台日志
            });

            serviceCollection.AddTransient<OrderServices>();

            // 构建容器
            IServiceProvider service = serviceCollection.BuildServiceProvider();
            #region 使用CreateLogger构建ILogger

            var orderServices = service.GetService<OrderServices>();

            // 获取ILoggerFactory服务
            ILoggerFactory loggerFactory = service.GetService<ILoggerFactory>();
            // 创建日志记录器，指定日志级别的key
            // 使用
            //ILogger alogger = loggerFactory.CreateLogger("Default");
            //ILogger alogger = loggerFactory.CreateLogger<OrderServices>();
            //alogger.LogDebug("debug");
            //alogger.LogInformation("jee");
            //alogger.LogError("heiheihei");
            #endregion

            #endregion
            Console.ReadKey();
            Console.WriteLine("Hello World!");
            //F12查看源代码  工具-选项-文本编辑器-C＃-高级-启用导航到反编译源码
        }

        /// <summary>
        /// 日志作用域
        /// </summary>
        static void LoggingScope()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var config = configurationBuilder.Build();
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(p => config);//使用工厂模式注入

            // 注册服务
            serviceCollection.AddLogging(builder =>
            {
                // 日志配置
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();// 控制台日志
                builder.AddDebug();
            });
            // 构建容器
            IServiceProvider service = serviceCollection.BuildServiceProvider();
            var logger = service.GetService<ILogger<Program>>();
            using (logger.BeginScope("ScopeId:{scopeId}",Guid.NewGuid()))
            {
                logger.LogDebug("debug");
                logger.LogInformation("jee");
                logger.LogError("heiheihei");
            }

        }
    }
}
