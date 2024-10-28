using System.ComponentModel.DataAnnotations;

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

        public string HabitacionImg { get; set; }

        public ICollection<ReservaHabitacion> Habitaciones { get; set; }
    }
}
