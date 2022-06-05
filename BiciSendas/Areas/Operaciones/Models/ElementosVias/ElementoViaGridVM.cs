using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.ElementosVias
{
    [Serializable]
    public class ElementoViaGridVM
    {
        public int Id { get; set; }

        [Display(Name = nameof(ElementoViaStrings.Nombre), ResourceType = typeof(ElementoViaStrings))]
        public string? Nombre { get; set; }
    }
}
