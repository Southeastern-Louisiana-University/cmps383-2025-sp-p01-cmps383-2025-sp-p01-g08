using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Selu383.SP25.Api;
using Selu383.SP25.Api.Controllers;
using System;
using System.Linq;
using Selu383.SP25.Api.DTO;
using Selu383.SP25.Api.Entities;


namespace Selu383.SP25.Api.Entities;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new DataContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<DataContext>>()))
        {
            // Look for any movies.
            if (context.Theaters.Any())
            {
                return;   // DB has been seeded
            }
            context.Theaters.AddRange(
                new Theater
                {
                    Name = "Santikos",
                    Address = "Slidell",
                    SeatCount = 40
                },
                new Theater
                {
                    Name = "Regal",
                    Address = "Covington",
                    SeatCount = 40
                },
                new Theater
                {
                    Name = "AMC",
                    Address = "Hammond",
                    SeatCount = 40
                }
            );
            context.SaveChanges();
        }
    }
}
