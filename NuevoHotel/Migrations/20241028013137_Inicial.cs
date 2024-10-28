using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NuevoHotel.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Habitacion",
                columns: table => new
                {
                    CodigoHabitacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NumeroHabitacion = table.Column<int>(type: "int", nullable: false),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    PrecioDia = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacion", x => x.CodigoHabitacion);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Restaurante",
                columns: table => new
                {
                    CodigoRestaurante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ubicacion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurante", x => x.CodigoRestaurante);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Salon",
                columns: table => new
                {
                    CodigoSalon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreSalon = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacidad = table.Column<int>(type: "int", nullable: false),
                    PrecioHora = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Estado = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salon", x => x.CodigoSalon);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReservaHabitacion",
                columns: table => new
                {
                    CodigoReserva = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoHabitacion = table.Column<int>(type: "int", nullable: false),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FechaSalida = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EstadoReserva = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HabitacionCodigoHabitacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaHabitacion", x => x.CodigoReserva);
                    table.ForeignKey(
                        name: "FK_ReservaHabitacion_Habitacion_HabitacionCodigoHabitacion",
                        column: x => x.HabitacionCodigoHabitacion,
                        principalTable: "Habitacion",
                        principalColumn: "CodigoHabitacion",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReservaRestaurante",
                columns: table => new
                {
                    CodigoReservaRestaurante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false),
                    CodigoRestaurante = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraIngreso = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EstadoReserva = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RestauranteCodigoRestaurante = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaRestaurante", x => x.CodigoReservaRestaurante);
                    table.ForeignKey(
                        name: "FK_ReservaRestaurante_Restaurante_RestauranteCodigoRestaurante",
                        column: x => x.RestauranteCodigoRestaurante,
                        principalTable: "Restaurante",
                        principalColumn: "CodigoRestaurante",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ReservaSalon",
                columns: table => new
                {
                    CodigoReservaSalon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodigoUsuario = table.Column<int>(type: "int", nullable: false),
                    CodigoSalon = table.Column<int>(type: "int", nullable: false),
                    FechaReserva = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HoraIngreso = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HoraSalida = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    EstadoReserva = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SalonCodigoSalon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservaSalon", x => x.CodigoReservaSalon);
                    table.ForeignKey(
                        name: "FK_ReservaSalon_Salon_SalonCodigoSalon",
                        column: x => x.SalonCodigoSalon,
                        principalTable: "Salon",
                        principalColumn: "CodigoSalon",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaHabitacion_HabitacionCodigoHabitacion",
                table: "ReservaHabitacion",
                column: "HabitacionCodigoHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaRestaurante_RestauranteCodigoRestaurante",
                table: "ReservaRestaurante",
                column: "RestauranteCodigoRestaurante");

            migrationBuilder.CreateIndex(
                name: "IX_ReservaSalon_SalonCodigoSalon",
                table: "ReservaSalon",
                column: "SalonCodigoSalon");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservaHabitacion");

            migrationBuilder.DropTable(
                name: "ReservaRestaurante");

            migrationBuilder.DropTable(
                name: "ReservaSalon");

            migrationBuilder.DropTable(
                name: "Habitacion");

            migrationBuilder.DropTable(
                name: "Restaurante");

            migrationBuilder.DropTable(
                name: "Salon");
        }
    }
}
