using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;
using System.Reflection.Metadata;

namespace Selu383.SP25.Api
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SP25-P01-G08;Trusted_Connection=True");
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
