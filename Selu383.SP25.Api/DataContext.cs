using Microsoft.EntityFrameworkCore;
using Selu383.SP25.Api.Entities;
using System.Reflection.Metadata;

namespace Selu383.SP25.Api
{
    public class DataContext : DbContext
    {

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}
