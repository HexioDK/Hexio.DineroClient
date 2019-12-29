using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Hexio.DineroClient.Auth;
using Hexio.DineroClient.Models.Products;
using Hexio.DineroClient.Module;
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
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var settings = _configuration.GetSection("DineroApiSettings").Get<SingleDineroAccountApiSettings>();
            
            var module = new DineroModule(settings);
            
            builder.RegisterModule(module);
        }

        public async Task GetMyProduct(IDineroClient client, IDineroAuthClient authClient, SingleDineroAccountApiSettings settings)
        {
            await client.SetAuthorizationHeader(authClient, settings.ApiKey, settings.OrganizationId);

            var query = new QueryCreator<ProductReadModel>()
                .Where(x => x.Name, QueryOperator.Eq, "MyProduct")
                .Include(x => x.TotalAmount);

            var products = await client.GetProducts(query);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDineroClient client, IDineroAuthClient dineroAuthClient, SingleDineroAccountApiSettings dineroApiSettings)
        {
            GetMyProduct(client, dineroAuthClient, dineroApiSettings).GetAwaiter().GetResult();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}