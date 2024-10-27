using System.ComponentModel.DataAnnotations;

namespace NuevoHotel.Models
{
    public class ReservaHabitacion
    {
        [Key]
        public int CodigoReserva { get; set; }
        public int CodigoHabitacion { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string EstadoReserva { get; set; }

        public Habitacion Habitacion { get; set; }
    }
}
