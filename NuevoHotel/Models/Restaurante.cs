using System.ComponentModel.DataAnnotations;

namespace NuevoHotel.Models
{
    public class Restaurante
    {
        [Key]
        public int CodigoRestaurante { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public int Capacidad { get; set; }

        public ICollection<ReservaRestaurante> reservarestaurantes { get; set; }
    }
}
