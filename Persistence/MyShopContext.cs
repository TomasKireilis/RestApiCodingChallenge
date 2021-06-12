using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class MyShopContext : DbContext
    {
        public MyShopContext(DbContextOptions contextOptions) : base(contextOptions)
        {
        }

        public DbSet<WeatherForecast> WeatherForecast { get; set; }
    }
}