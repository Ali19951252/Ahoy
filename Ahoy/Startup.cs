using DataBase;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using ProjectCommons.CacheCommon.CacheServiceCommon;
using ProjectCommons.CosmosCommon.CosmosRegistration;
using System;


namespace Ahoy
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ahoy", Version = "v1" });
                c.CustomSchemaIds(type => type.FullName.Replace("+", "_"));
            });
                services.AddDistributedRedisCache(o =>
            {
                o.Configuration = Configuration.GetValue<string>("Redis:ConnectionString");
            });
            services.AddCosmosDbServices(Configuration);
            services.AddScoped<CacheService>();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("HotelDbConnection")));
           

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
         
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ahoy v1"));
        

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
