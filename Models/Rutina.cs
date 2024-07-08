using Obligatorio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio.Models
{
    public class Rutina
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public TipoRutina? TipoRutina { get; set; } // pueden ser: Salud, Competición amateur, Competición profesional
        public int CalificacionPromedio { get; set; }
        public int IdTipoRutina { get; set; }
        public ICollection<Ejercicio>? Ejercicios { get; set; }
        public ICollection<SocioRutina>? SocioRutinas { get; set; } = new List<SocioRutina>();
        public ICollection<RutinaEjercicio>? RutinaEjercicios { get; set; }

    }
}