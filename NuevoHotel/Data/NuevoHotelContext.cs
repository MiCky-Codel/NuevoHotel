using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NuevoHotel.Models;

namespace NuevoHotel.Data
{
    public class NuevoHotelContext : DbContext
    {
        public NuevoHotelContext (DbContextOptions<NuevoHotelContext> options)
            : base(options)
        {
        }

        public DbSet<NuevoHotel.Models.Habitacion> Habitacion { get; set; } = default!;
        public DbSet<NuevoHotel.Models.ReservaHabitacion> ReservaHabitacion { get; set; } = default!;
        public DbSet<NuevoHotel.Models.ReservaRestaurante> ReservaRestaurante { get; set; } = default!;
        public DbSet<NuevoHotel.Models.ReservaSalon> ReservaSalon { get; set; } = default!;
        public DbSet<NuevoHotel.Models.Restaurante> Restaurante { get; set; } = default!;
        public DbSet<NuevoHotel.Models.Salon> Salon { get; set; } = default!;
    }
}
