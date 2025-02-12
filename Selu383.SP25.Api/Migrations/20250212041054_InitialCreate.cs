using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Selu383.SP25.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Theaters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeatCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theaters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Theaters",
                columns: new[] { "Id", "Address", "Name", "SeatCount" },
                values: new object[,]
                {
                    { 1, "Slidell, LA", "The Grand Slidell Santikos", 250 },
                    { 2, "Hammond, LA", "AMC Hammond Palace 10", 300 },
                    { 3, "Covington, LA", "Regal Covington Stadium 14", 150 },
                    { 4, "Baton Rouge, LA", "AMC Mall of Louisiana 15", 250 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Theaters");
        }
    }
}
