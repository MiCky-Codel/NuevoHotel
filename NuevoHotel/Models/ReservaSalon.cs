using System.ComponentModel.DataAnnotations;

namespace NuevoHotel.Models
{
    public class ReservaSalon
    {
        [Key]
        public int CodigoReservaSalon { get; set; }
        public int CodigoUsuario { get; set; }
        public int CodigoSalon { get; set; }
        public DateTime FechaReserva { get; set; }
        public TimeSpan HoraIngreso { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public string EstadoReserva { get; set; }

        public string ResSalImg { get; set; }

        public Salon Salon { get; set; }
    }
}
