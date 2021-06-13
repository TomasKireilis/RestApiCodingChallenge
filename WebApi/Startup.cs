using System.IO;
using Application;
using Application.Commands.SeedCommands;
using Application.Commands.WeatherForecastCommands;
using Application.Queries;
using Application.Repositories;
using Application.Services;
using Infrastructure.Services.WeatherForecast;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using System.Net.Http;
using Microsoft.Extensions.Logging;

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
            services.AddTransient<IWeatherForecastRepository, WeatherForecastRepository>();
            services.AddTransient<HttpClient>();

            services.AddTransient<IWeatherForecastService>(x => new WeatherForecastService(
                x.GetRequiredService<HttpClient>(),

                Configuration["ConnectionStrings:WeatherForecastServiceBaseUrl"]));

            services.AddDbContext<WeatherForecastContext>(
                opt => opt.UseSqlServer(Configuration["ConnectionStrings:LocalDbConnectionString"]));

            //Queries
            services.AddTransient<IGetWeatherForecastQuery, GetWeatherForecastQuery>();

            //Commands
            services.AddTransient<ICreateWeatherForecastCommand, CreateWeatherForecastCommand>();
            services.AddTransient<IUpdateWeatherForecastCommand, UpdateWeatherForecastCommand>();
            services.AddTransient<IDeleteWeatherForecastCommand, DeleteWeatherForecastCommand>();

            services.AddTransient<ISeedDatabaseCommand, SeedDatabaseCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\AppLogs.txt");

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