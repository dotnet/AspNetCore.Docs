using JSON.Models;
using Microsoft.EntityFrameworkCore;

namespace JSON.Data {
    public class AppDbContext : DbContext {
        public DbSet<WeatherForecast> Forecasts => Set<WeatherForecast>();

        public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : base(optionsBuilder)
        {
            
        }
    }
}
