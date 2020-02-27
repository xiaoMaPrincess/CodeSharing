﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace DotNetCoreConfigurationDemo
{
    /// <summary>
    /// .netcore配置系统
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region 内存配置提供程序
            //// 构建配置对象
            //IConfigurationBuilder builder = new ConfigurationBuilder();
            //// 添加内存配置提供程序
            //builder.AddInMemoryCollection(new Dictionary<string, string>()
            //{
            //    { "key1","value1"},
            //    { "key2","value2"},
            //    { "section1:key3","value3"},
            //    { "section1:key4","value4"},
            //});

            ////构建配置项的根
            //IConfigurationRoot configurationRoot = builder.Build();

            ////IConfiguration  configuration= configurationRoot;
            //Console.WriteLine(configurationRoot["key1"]);
            //Console.WriteLine(configurationRoot["key2"]);
            ////以：为标识，获取部分数据
            //IConfigurationSection section = configurationRoot.GetSection("section1");
            //Console.WriteLine(section["key3"]);
            //Console.WriteLine(section["key4"]);
            #endregion


            #region 命令行配置提供程序
            //var builder = new ConfigurationBuilder();
            //builder.AddCommandLine(args);
            //var configurationRoot = builder.Build();
            #endregion

            #region 环境变量配置提供程序
            //var builder = new ConfigurationBuilder();
            //builder.AddEnvironmentVariables();
            //var configurationRoot = builder.Build();
            //Console.WriteLine($"key1:{configurationRoot["key1"]}");

            //// 分层可以使用双下划线，linux不支持：
            //// 在读取分层时可以使用:
            //var section= configurationRoot.GetSection("SECTION");
            //Console.WriteLine($"key2:{section["KEY2"]}");

            #region 前缀过滤
            //var builder = new ConfigurationBuilder();
            //// 应用启动时只会加载使用指定前缀的key
            //builder.AddEnvironmentVariables("jee_");
            //var configurationRoot = builder.Build();
            //Console.WriteLine($"key1:{configurationRoot["key1"]}");
            //Console.WriteLine($"key2:{configurationRoot["key2"]}");
            #endregion
            #endregion

            #region 文件配置提供程序
            var builder = new ConfigurationBuilder();
            // 指定加载的json文件，并指定文件是否可选，是否监听文件的变化
            builder.AddJsonFile("appsettings.json", optional: false,reloadOnChange:true);
            var configRoot = builder.Build();
            Console.WriteLine($"key1:{configRoot["key1"]}");
            Console.WriteLine($"key2:{configRoot["key2"]}");
            #endregion
            Console.ReadKey();
        }
    }
}
