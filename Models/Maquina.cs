using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Models
{
    public class Maquina
    {
        [Key] public int IdMaquina { get; set; }
        public DateTime FechaCompra { get; set; }
        public int PrecioCompra { get; set; }
        public int VidaUtil { get; set; }
        public bool Disponible { get; set; }
        [ForeignKey("Maquinas")]
        [Display(Name = "Tipo de maquina")]
        [Required(ErrorMessage = "El campo es requerido")]
        public int TipoDeMaquinaId { get; set; }  // Clave foránea
        public TipoDeMaquina? TipoDeMaquina { get; set; }
        public int LocalId { get; set; }  // Clave foránea
        public Local? Local { get; set; }
        public int AniosVidaUtilRestantes
        {
            get
            {
                var anosUso = DateTime.Now.Year - FechaCompra.Year;
                var anosRestantes = VidaUtil - anosUso;
                return anosRestantes > 0 ? anosRestantes : 0; // Si es negativo, devuelve 0
            }
        }
    }
}