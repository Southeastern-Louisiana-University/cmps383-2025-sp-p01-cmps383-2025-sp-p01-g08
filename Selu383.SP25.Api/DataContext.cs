using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;
using System.Reflection.Metadata;

namespace Selu383.SP25.Api
{
    public class MyDataContext : DbContext
    {

        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SP25-P01-G08;Trusted_Connection=True");
        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public DbSet<TheaterDto> Theaters { get; set; }

        public static void SeedData(MyDataContext context)
        {
            if (!context.Theaters.Any()) // Avoid duplicate seeding
            {
                context.Theaters.AddRange(new List<TheaterDto>
            {
                new TheaterDto { Id = 1, Name = "Santikos", Address = "Slidell", seatCount = 20 },
                new TheaterDto { Id = 2, Name = "AMC", Address = "Hammond", seatCount = 30 },
                });

                context.SaveChanges();
            }
        }
    }
}
