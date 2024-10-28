using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuevoHotel.Migrations
{
    /// <inheritdoc />
    public partial class Imagen2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResSalImg",
                table: "ReservaSalon",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ResRestImg",
                table: "ReservaRestaurante",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ReservaHaImg",
                table: "ReservaHabitacion",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResSalImg",
                table: "ReservaSalon");

            migrationBuilder.DropColumn(
                name: "ResRestImg",
                table: "ReservaRestaurante");

            migrationBuilder.DropColumn(
                name: "ReservaHaImg",
                table: "ReservaHabitacion");
        }
    }
}
