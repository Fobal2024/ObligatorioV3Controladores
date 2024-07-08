using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models
{
    public class SocioRutina
    {
        public int Calificacion { get; set; }
        public int IdSocio { get; set; }
        public Socio? Socio { get; set; }
        public int IdRutina { get; set; }
        public Rutina? Rutina { get; set; }
    }
}
