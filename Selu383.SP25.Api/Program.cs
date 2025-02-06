using Microsoft.EntityFrameworkCore;
using NSwag;
using System.Reflection.Metadata;



namespace Selu383.SP25.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddOpenApiDocument(options => {
                options.PostProcess = document =>
                {
                    document.Info = new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "Development API",
                        Description = "An ASP.NET Core Web API for managing ToDo items",
                        TermsOfService = "https://example.com/terms",
                        Contact = new OpenApiContact
                        {
                            Name = "Example Contact",
                            Url = "https://example.com/contact"
                        },
                        License = new OpenApiLicense
                        {
                            Name = "Example License",
                            Url = "https://example.com/license"
                        }
                    };
                };
            });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            if (app.Environment.IsDevelopment())
            {
                // Add OpenAPI 3.0 document serving middleware
                // Available at: https://localhost:<5144>/swagger/v1/swagger.json
                app.UseOpenApi();

                // Add web UIs to interact with the document
                // Available at: https://localhost:<5144>/swagger
                app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
            }



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
