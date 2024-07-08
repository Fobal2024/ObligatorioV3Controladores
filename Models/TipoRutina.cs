using System.ComponentModel.DataAnnotations;

namespace Obligatorio.Models
{
    public class TipoRutina
    {
      [Key]
      public int IdTipoRutina { get; set; }   
      public string? Nombre { get; set; }
      public ICollection<Rutina>? Rutinas { get; set; }
    }
}
