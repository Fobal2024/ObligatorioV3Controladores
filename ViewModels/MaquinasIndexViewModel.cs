using Obligatorio.Models;

namespace Obligatorio.ViewModels
{
    public class MaquinasIndexViewModel
    {
        public int? LocalId { get; set; }
        public required IEnumerable<Maquina> Maquinas { get; set; }
    }
}
