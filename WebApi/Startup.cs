using Application;
using Application.Commands;
using Infrastructure.Services.WeatherForecast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System.Net.Http;
using Application.Commands.SeedCommands;

namespace WebApi
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

            services.AddTransient<IDataSeeder, WeatherForecastDataSeeder>();
            services.AddTransient<HttpClient>();

            services.AddTransient<IWeatherForecastService>(x => new WeatherForecastService(
                x.GetRequiredService<HttpClient>(),

                Configuration["ConnectionStrings:WeatherForecastServiceBaseUrl"]));

            services.AddDbContext<WeatherForecastContext>(
                opt => opt.UseSqlServer(Configuration["ConnectionStrings:LocalDbConnectionString"]));

            //Queries
            services.AddTransient<ISeedDatabaseCommand, SeedDatabaseCommand>();

            //Commands
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