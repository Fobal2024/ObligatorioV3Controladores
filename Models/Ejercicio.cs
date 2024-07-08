using Obligatorio.Models;
using System;

namespace Obligatorio.Models
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Maquina? MaquinaNecesaria { get; set; } // Puede ser null si no preciso usar una máquina
        public ICollection<Rutina>? Rutina { get; set; }
        public ICollection<RutinaEjercicio>? RutinaEjercicios { get; set; }
    }
}




    
