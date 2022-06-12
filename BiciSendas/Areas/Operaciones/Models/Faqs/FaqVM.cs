using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqVM
    {
        public int IdFaq { get; set; }

        [Display(Name = nameof(FaqStrings.TituloFaq), ResourceType = typeof(FaqStrings))]
        [Required(ErrorMessageResourceName = nameof(FaqStrings.ErrorTituloObligatorio), ErrorMessageResourceType = typeof(FaqStrings))]
        [MaxLength(200, ErrorMessageResourceName = nameof(FaqStrings.ErrorLongitudTitulo), ErrorMessageResourceType = typeof(FaqStrings))]
        public string? Titulo { get; set; }

        [Display(Name = nameof(FaqStrings.Posicion), ResourceType = typeof(FaqStrings))]
        public int? Posicion { get; set; }

        [Display(Name = nameof(FaqStrings.Descripcion), ResourceType = typeof(FaqStrings))]
        [Required(ErrorMessageResourceName = nameof(FaqStrings.ErrorDescripcionObligatorio), ErrorMessageResourceType = typeof(FaqStrings))]
        [MaxLength(500, ErrorMessageResourceName = nameof(FaqStrings.ErrorLongitudDescripcion), ErrorMessageResourceType = typeof(FaqStrings))]
        public string? Descripcion { get; set; }
    }
}
