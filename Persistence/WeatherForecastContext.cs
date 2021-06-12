using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class WeatherForecastContext : DbContext
    {
        public WeatherForecastContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
    }
}