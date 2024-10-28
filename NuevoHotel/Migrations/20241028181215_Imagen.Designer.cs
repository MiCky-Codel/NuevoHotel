﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NuevoHotel.Data;

#nullable disable

namespace NuevoHotel.Migrations
{
    [DbContext(typeof(NuevoHotelContext))]
    [Migration("20241028181215_Imagen")]
    partial class Imagen
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("NuevoHotel.Models.Habitacion", b =>
                {
                    b.Property<int>("CodigoHabitacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodigoHabitacion"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HabitacionImg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NumeroHabitacion")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioDia")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("CodigoHabitacion");

                    b.ToTable("Habitacion");
                });

            modelBuilder.Entity("NuevoHotel.Models.ReservaHabitacion", b =>
                {
                    b.Property<int>("CodigoReserva")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodigoReserva"));

                    b.Property<int>("CodigoHabitacion")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("EstadoReserva")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HabitacionCodigoHabitacion")
                        .HasColumnType("int");

                    b.HasKey("CodigoReserva");

                    b.HasIndex("HabitacionCodigoHabitacion");

                    b.ToTable("ReservaHabitacion");
                });

            modelBuilder.Entity("NuevoHotel.Models.ReservaRestaurante", b =>
                {
                    b.Property<int>("CodigoReservaRestaurante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodigoReservaRestaurante"));

                    b.Property<int>("CodigoRestaurante")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("EstadoReserva")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("HoraIngreso")
                        .HasColumnType("time(6)");

                    b.Property<int>("RestauranteCodigoRestaurante")
                        .HasColumnType("int");

                    b.HasKey("CodigoReservaRestaurante");

                    b.HasIndex("RestauranteCodigoRestaurante");

                    b.ToTable("ReservaRestaurante");
                });

            modelBuilder.Entity("NuevoHotel.Models.ReservaSalon", b =>
                {
                    b.Property<int>("CodigoReservaSalon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodigoReservaSalon"));

                    b.Property<int>("CodigoSalon")
                        .HasColumnType("int");

                    b.Property<int>("CodigoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("EstadoReserva")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaReserva")
                        .HasColumnType("datetime(6)");

                    b.Property<TimeSpan>("HoraIngreso")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HoraSalida")
                        .HasColumnType("time(6)");

                    b.Property<int>("SalonCodigoSalon")
                        .HasColumnType("int");

                    b.HasKey("CodigoReservaSalon");

                    b.HasIndex("SalonCodigoSalon");

                    b.ToTable("ReservaSalon");
                });

            modelBuilder.Entity("NuevoHotel.Models.Restaurante", b =>
                {
                    b.Property<int>("CodigoRestaurante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodigoRestaurante"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RestautanteImg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodigoRestaurante");

                    b.ToTable("Restaurante");
                });

            modelBuilder.Entity("NuevoHotel.Models.Salon", b =>
                {
                    b.Property<int>("CodigoSalon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodigoSalon"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NombreSalon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("PrecioHora")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("SalonImg")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodigoSalon");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("NuevoHotel.Models.ReservaHabitacion", b =>
                {
                    b.HasOne("NuevoHotel.Models.Habitacion", "Habitacion")
                        .WithMany("Habitaciones")
                        .HasForeignKey("HabitacionCodigoHabitacion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Habitacion");
                });

            modelBuilder.Entity("NuevoHotel.Models.ReservaRestaurante", b =>
                {
                    b.HasOne("NuevoHotel.Models.Restaurante", "Restaurante")
                        .WithMany("reservarestaurantes")
                        .HasForeignKey("RestauranteCodigoRestaurante")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurante");
                });

            modelBuilder.Entity("NuevoHotel.Models.ReservaSalon", b =>
                {
                    b.HasOne("NuevoHotel.Models.Salon", "Salon")
                        .WithMany("reservasalon")
                        .HasForeignKey("SalonCodigoSalon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("NuevoHotel.Models.Habitacion", b =>
                {
                    b.Navigation("Habitaciones");
                });

            modelBuilder.Entity("NuevoHotel.Models.Restaurante", b =>
                {
                    b.Navigation("reservarestaurantes");
                });

            modelBuilder.Entity("NuevoHotel.Models.Salon", b =>
                {
                    b.Navigation("reservasalon");
                });
#pragma warning restore 612, 618
        }
    }
}
