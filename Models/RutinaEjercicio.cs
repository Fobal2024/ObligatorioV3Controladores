namespace Obligatorio.Models
{
    public class RutinaEjercicio
    {
        
        public int IdRutina { get; set; }
        public Rutina? Rutina { get; set; }
        public int IdEjercicio { get; set; }
        public Ejercicio? Ejercicio { get; set; }
        public int Repeticiones { get; set; }
        public int Series { get; set; }
    }
}
