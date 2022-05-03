using BiciSendas.Recursos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.ElementosVias
{
    [Serializable]
    public class ElementoViaIndexVM
    {
        public byte? NumPagina { get; set; }

        public List<SelectListItem>? Paginas { get; set; }

        [Display(Name = nameof(ElementoViaStrings.Nombre), ResourceType = typeof(ElementoViaStrings))]
        [Required(ErrorMessageResourceName = nameof(ElementoViaStrings.NombreObligatorio), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        public string? Nombre { get; set; }

        [Display(Name = nameof(ElementoViaStrings.TipoElemento), ResourceType = typeof(ElementoViaStrings))]
        [Required(ErrorMessageResourceName = nameof(ElementoViaStrings.TipoElementoObligatorio), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        public string? TipoElemento { get; set; }

        [Display(Name = nameof(ElementoViaStrings.Identificador), ResourceType = typeof(ElementoViaStrings))]
        [Required(ErrorMessageResourceName = nameof(ElementoViaStrings.IdentificadorObligatorio), ErrorMessageResourceType = typeof(ElementoViaStrings))]
        public string? Identificador { get; set; }
    }
}
