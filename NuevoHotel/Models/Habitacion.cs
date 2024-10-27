﻿using System.ComponentModel.DataAnnotations;

namespace NuevoHotel.Models
{
    public class Habitacion
    {
        [Key]
        public int CodigoHabitacion { get; set; }
        public int NumeroHabitacion { get; set; }
        public int Capacidad { get; set; }
        public decimal PrecioDia { get; set; }
        public string Estado { get; set; }

        public ICollection<Reserva> Habitaciones { get; set; }
    }
}