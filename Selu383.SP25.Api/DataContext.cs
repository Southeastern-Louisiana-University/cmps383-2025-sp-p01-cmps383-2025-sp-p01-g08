using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;

namespace Selu383.SP25.Api
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Theater> Theaters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Theater>(b =>
            {
                b.HasKey(x => x.Id);
                b.HasData( // This inserts initial records into the database
                    new Theater { Id = 1, Name = "The Grand Slidell Santikos", Address = "Slidell, LA", SeatCount = 250 },
                    new Theater { Id = 2, Name = "AMC Hammond Palace 10", Address = "Hammond, LA", SeatCount = 300 },
                    new Theater { Id = 3, Name = "Regal Covington Stadium 14", Address = "Covington, LA", SeatCount = 150 },
                    new Theater { Id = 4, Name = "AMC Mall of Louisiana 15", Address = "Baton Rouge, LA", SeatCount = 250 }
                );
            });
        }
    }
}