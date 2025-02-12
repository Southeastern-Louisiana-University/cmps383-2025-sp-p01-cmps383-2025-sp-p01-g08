using Microsoft.EntityFrameworkCore;


namespace Selu383.SP25.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyDataContext")));

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataContext>();
                context.Database.Migrate();
            }

            if (app.Environment.IsDevelopment())
            {
                //Enable Swagger UI in development
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Selu383 API V1");
                    c.RoutePrefix = string.Empty;
                }
                );
            }

            app.UseHttpsRedirection();
                
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
