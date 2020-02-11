using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using DotNetCoreAutofacDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCoreAutofacDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }
        //autofac依赖注入
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //注入时默认生命周期为瞬时InstancePerDependency，范围内单例：InstancePerLifetimeScope，单例：SingleInstance
            //builder.RegisterType<CoreService>().As<ICoreService>();//.SingleInstance();

            #region 名称注册
            //builder.RegisterType<CoreService2>().Named<ICoreService>("services2");
            #endregion

            #region 属性注入
            //builder.RegisterType<CoreName>();
            //builder.RegisterType<CoreService2>().As<ICoreService>().PropertiesAutowired();
            #endregion
            #region AOP
            builder.RegisterType<MyInterceptor>();
            builder.RegisterType<CoreService2>().As<ICoreService>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();//接口拦截器
            #endregion
        }

        public ILifetimeScope AutofacContainer { get; set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            var service1 = this.AutofacContainer.Resolve<ICoreService>();
            service1.OutputHashCode();
            //// 根据名称获取实例
            //var service = this.AutofacContainer.ResolveNamed<ICoreService>("service2");
            //service.OutputHashCode();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
