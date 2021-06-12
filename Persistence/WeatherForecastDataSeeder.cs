using System;
using System.Collections.Generic;
using Application;
using Microsoft.EntityFrameworkCore;
using WebApi.Services;

namespace Persistence
{
    public class WeatherForecastDataSeeder : IDataSeeder
    {
        private readonly MyShopContext _ctx;
        private readonly IWeatherForecastService _weatherForecastService;
        private readonly List<int> _locationIds = new List<int>() { 44501, 12451 };

        public WeatherForecastDataSeeder(IDbContextFactory<MyShopContext> ctx, IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
            _ctx = ctx.CreateDbContext();
        }

        public void Seed()
        {
            Console.WriteLine("Creating db...");
            _ctx.Database.EnsureCreated();
            Console.WriteLine("Seeding...");
            if (!_ctx.WeatherForecast.Any())
            {
                var weatherForecasts = _weatherForecastService.GetForecastsInRegion(_locationIds);
            }
        }
    }
}