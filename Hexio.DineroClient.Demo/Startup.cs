using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Hexio.DineroClient.Auth;
using Hexio.DineroClient.Authorization;
using Hexio.DineroClient.Models.Products;
using Hexio.DineroClient.Module;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hexio.DineroClient.Demo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddHttpClient();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var settings = _configuration.GetSection("DineroApiSettings").Get<SingleDineroAccountApiSettings>();
            var vismaConnectSettings = _configuration.GetSection("VismaConnectSettings").Get<VismaConnectSettings>();
            
            var module = new DineroModule(settings, vismaConnectSettings);
            
            builder.RegisterModule(module);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDineroClient client, IDineroAuthClient dineroAuthClient, SingleDineroAccountApiSettings dineroApiSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}