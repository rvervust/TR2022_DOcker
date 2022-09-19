using Microsoft.EntityFrameworkCore;

namespace Traineeship_database;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
    {
        // Creates the database !! Just for DEMO !! in production code you have to handle it differently!  
        this.Database.EnsureCreated();
    }

    public DbSet<WeatherForecast> WeatherForecast { get; set; }
}