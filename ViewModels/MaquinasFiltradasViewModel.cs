using Obligatorio.Models;

namespace Obligatorio.ViewModels
{
    public class MaquinasFiltradasViewModel
    {
        public string Tipo { get; set; }
        public int Cantidad { get; set; }
        public int? LocalId { get; set; } // Agrego esta propiedad
        public List<Maquina>? Maquinas { get; set; } // Lista de máquinas filtradas
    }
}
