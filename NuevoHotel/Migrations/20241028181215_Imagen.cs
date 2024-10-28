using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuevoHotel.Migrations
{
    /// <inheritdoc />
    public partial class Imagen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SalonImg",
                table: "Salon",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RestautanteImg",
                table: "Restaurante",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HabitacionImg",
                table: "Habitacion",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalonImg",
                table: "Salon");

            migrationBuilder.DropColumn(
                name: "RestautanteImg",
                table: "Restaurante");

            migrationBuilder.DropColumn(
                name: "HabitacionImg",
                table: "Habitacion");
        }
    }
}
