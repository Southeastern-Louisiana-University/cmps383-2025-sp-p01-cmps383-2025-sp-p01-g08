using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;
using Selu383.SP25.Api.NewFolder;

namespace Selu383.SP25.Api
{
    public class MyDataContext : DbContext
    {
        public MyDataContext(DbContextOptions<MyDataContext> options) : base(options)
        {
        }

        public DbSet<Theater> Theaters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Theater>(b =>
            {
                b.Property(x => x.Id).IsRequired();
            });

            // Seeding data for Country
            modelBuilder.Entity<Theater>().HasData(
                new Theater { Id = 1, Name = "Santikos", Address = "Slidell", SeatCount = 20 },
                new Theater { Id = 2, Name = "Regal", Address = "Covington", SeatCount = 30 },
                new Theater { Id = 3, Name = "AMC", Address = "Hammond", SeatCount = 40 }
            );
        }
    }
}
