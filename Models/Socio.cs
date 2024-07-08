using Obligatorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

                                    // Socio y Rutina tienen una relación N-N
namespace Obligatorio.Models
{
    public class Socio : Persona 
    {
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "El Email es requerido")]
        [EmailAddress(ErrorMessage = "Formato de Email inválido")]
        public string? Email { get; set; }
        public Local? LocalAsociado { get; set; }
        [ForeignKey("Local")]
        [Display(Name = "Local")]
        [Required(ErrorMessage = "El LocalId es requerido")]
        public int LocalId { get; set; }
        public int IdTipoRutina { get; set; }
        public ICollection<SocioRutina>? SocioRutinas { get; set; }
    }
}
