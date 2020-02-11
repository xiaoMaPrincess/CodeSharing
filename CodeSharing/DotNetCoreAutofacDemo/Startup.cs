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
        //autofac����ע��
        public void ConfigureContainer(ContainerBuilder builder)
        {
            //ע��ʱĬ����������Ϊ˲ʱInstancePerDependency����Χ�ڵ�����InstancePerLifetimeScope��������SingleInstance
            //builder.RegisterType<CoreService>().As<ICoreService>();//.SingleInstance();

            #region ����ע��
            //builder.RegisterType<CoreService2>().Named<ICoreService>("services2");
            #endregion

            #region ����ע��
            //builder.RegisterType<CoreName>();
            //builder.RegisterType<CoreService2>().As<ICoreService>().PropertiesAutowired();
            #endregion
            #region AOP
            builder.RegisterType<MyInterceptor>();
            builder.RegisterType<CoreService2>().As<ICoreService>().PropertiesAutowired().InterceptedBy(typeof(MyInterceptor)).EnableInterfaceInterceptors();//�ӿ�������
            #endregion
        }

        public ILifetimeScope AutofacContainer { get; set; }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            var service1 = this.AutofacContainer.Resolve<ICoreService>();
            service1.OutputHashCode();
            //// �������ƻ�ȡʵ��
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
