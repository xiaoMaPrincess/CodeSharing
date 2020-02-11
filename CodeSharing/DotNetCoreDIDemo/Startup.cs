using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCoreDIDemo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetCoreDIDemo
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
            //services.AddScoped<ScopedService>();
            #region ����ģʽ��ע��
            services.AddSingleton<ISingletonService, SingletonService>();

            services.AddScoped<IScopedService, ScopedService>();

            services.AddTransient<ITransientService, TransientService>();
            #endregion

            #region ����ע��/ע�벻ͬʵ��
            services.TryAddSingleton<ISingletonService, SingletonService>();
            services.AddScoped<IOrderServices, OrderServices>();
            services.AddScoped<IOrderServices, OrderServicesEx>();
            #endregion
            #region �Ƴ����滻ע��
            //services.Replace(ServiceDescriptor.Singleton<IOrderService, OrderServiceEx>());
            //services.RemoveAll<ISingletonService>();
            #endregion
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
