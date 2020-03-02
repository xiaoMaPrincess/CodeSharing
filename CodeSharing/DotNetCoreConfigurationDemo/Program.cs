using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
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
            // 指定加载的json文件，并指定文件是否可选，是否监听文件的变化。 后添加的文件会覆盖之前的
            builder.AddJsonFile("appsettings.json", optional: false,reloadOnChange:true);
            var configRoot = builder.Build();
            //Console.WriteLine($"key1:{configRoot["key1"]}");
            //Console.WriteLine($"key2:{configRoot["key2"]}");

            #region 监听文件发生变化
            //IChangeToken token = configRoot.GetReloadToken();
            // 监听文件发生变化 v1
            //token.RegisterChangeCallback(Ads,configRoot);

            // v2
            //ChangeToken.OnChange(() => configRoot.GetReloadToken(), () =>
            // {
            //Console.WriteLine($"key1:{configRoot["key1"]}");
            //Console.WriteLine($"key2:{configRoot["key2"]}");
            //});
            #endregion

            #endregion

            // 强类型绑定,数据发现改变需要重新绑定
            Config config = new Config();
            configRoot.Bind(config);
            Console.WriteLine($"key1:{config.Key1}");
            Console.WriteLine($"key3:{config.Key3}");
            Console.ReadKey();
        }
        static void Ads(object obj)
        {
            Console.WriteLine("文件发生改变");
        }
    }

    /// <summary>
    /// 强类型配置类
    /// </summary>
    class Config
    {
        public string Key1 { get; set; }
        public string Key2 { get; set; }
        public int Key3 { get; set; }
        public bool Key4 { get; set; }
    }
}
