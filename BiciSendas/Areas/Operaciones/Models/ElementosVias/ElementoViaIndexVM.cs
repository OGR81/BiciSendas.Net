using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.ElementosVias
{
    [Serializable]
    public class ElementoViaIndexVM
    {
        [Display(Name = nameof(ElementoViaStrings.Nombre), ResourceType = typeof(ElementoViaStrings))]
        [Required(ErrorMessageResourceName = nameof(ElementoViaStrings.NombreObligatorio), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        [MaxLength(50, ErrorMessageResourceName = nameof(ElementoViaStrings.ErrorLongitudNombre), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        public string? Nombre { get; set; }

        [Display(Name = nameof(ElementoViaStrings.TipoElemento), ResourceType = typeof(ElementoViaStrings))]
        [Required(ErrorMessageResourceName = nameof(ElementoViaStrings.TipoElementoObligatorio), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        [MaxLength(50, ErrorMessageResourceName = nameof(ElementoViaStrings.ErrorLongitudTipoElemento), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        public string? TipoElemento { get; set; }

        [Display(Name = nameof(ElementoViaStrings.Identificador), ResourceType = typeof(ElementoViaStrings))]
        [Required(ErrorMessageResourceName = nameof(ElementoViaStrings.IdentificadorObligatorio), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        [MaxLength(50, ErrorMessageResourceName = nameof(ElementoViaStrings.ErrorLongitudIdentificador), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        public string? Identificador { get; set; }
    }
}
