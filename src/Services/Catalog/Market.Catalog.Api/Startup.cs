using Market.Catalog.Application.Interfaces;
using Market.Catalog.Application.Services;
using Market.Catalog.Data.Context;
using Market.Catalog.Data.Repository;
using Market.Catalog.Data.Seed;
using Market.Catalog.Data.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Threading.Tasks;

namespace Market.Catalog.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog Api", Version = "v1" });
            });

            var databseSetting = new DatabaseSetting();
            _configuration.GetSection(nameof(DatabaseSetting)).Bind(databseSetting);
            databseSetting.ConnectionString = Environment.GetEnvironmentVariable("ConnectionString");
            services.AddSingleton(databseSetting);

            services.AddSingleton<ICatalogDbContext, CatalogDbContext>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Market.Catalog.Api v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            SeedDatabase(app).Wait();
        }

        private async Task SeedDatabase(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ICatalogDbContext>();
            await new CatalogSeed(context).SeedDatabaseAsync();
        }
    }
}
