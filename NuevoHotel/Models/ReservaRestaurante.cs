using System.ComponentModel.DataAnnotations;

namespace NuevoHotel.Models
{
    public class ReservaRestaurante
    {
        [Key]
        public int CodigoReservaRestaurante { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoRestaurante { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public string EstadoReserva { get; set; }

        public string ResRestImg { get; set; }
        public Restaurante Restaurante { get; set; }
    }
}
