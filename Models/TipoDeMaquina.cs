using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorio.Models
{
    public class TipoDeMaquina
    {
        public string Nombre { get; set; } = string.Empty;
        public int Id { get; set; }
        public ICollection<Maquina>? Maquinas { get; set; }
        public int CantidadMaquinas => Maquinas?.Count ?? 0; //Agregué esta propiedad (funciona?)
    }
}