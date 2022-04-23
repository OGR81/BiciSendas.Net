using BiciSendas.Recursos;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqGridVM
    {
        [Display(Name = nameof(FaqStrings.Identificador), ResourceType = typeof(FaqStrings))]
        public string? Identificador { get; set; }

        [Display(Name = nameof(FaqStrings.Nombre), ResourceType = typeof(FaqStrings))]
        public string? Nombre { get; set; }
        [Display(Name = nameof(FaqStrings.Estado), ResourceType = typeof(FaqStrings))]
        public int? Estado { get; set; }
        [Display(Name = nameof(FaqStrings.FechaModificacion), ResourceType = typeof(FaqStrings))]
        public int? FechaModificacion { get; set; }
        [Display(Name = nameof(FaqStrings.Opciones), ResourceType = typeof(FaqStrings))]
        public string? Opciones { get; set; }

    }
}
