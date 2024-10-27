using System.ComponentModel.DataAnnotations;

namespace NuevoHotel.Models
{
    public class Salon
    {
        [Key]
        public int CodigoSalon { get; set; }
        public string NombreSalon { get; set; }
        public int Capacidad { get; set; }
        public decimal PrecioHora { get; set; }
        public string Estado { get; set; }

        public ICollection<ReservaSalon> reservasalon { get; set; }
    }
}
