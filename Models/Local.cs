using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Obligatorio.Models
{
    public class Local
    {
        [Key]
        public int Id { get; set; }
        //[Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string Ciudad { get; set; } = string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        //[Required]
        public Responsable? Responsable { get; set; }
        [Display(Name = "Responsable")]
        [Required(ErrorMessage = "El responsable es requerido")]
        [ForeignKey("Responsables")]
        public int ResponsableId { get; set; }
        public ICollection<Socio>? Socios { get; set; }
        public ICollection<Maquina>? Maquinas { get; set; }
        
        
        
    }
}


   
