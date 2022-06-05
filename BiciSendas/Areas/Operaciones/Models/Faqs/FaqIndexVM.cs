using BiciSendas.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqIndexVM
    {
        public byte? NumPagina { get; set; }
        public List<FaqGridVM>? Actuadores { get; set; }

        [Display(Name = nameof(FaqStrings.Categoria), ResourceType = typeof(FaqStrings))]
        public int? Categoria { get; set; }

        [Display(Name = nameof(FaqStrings.TituloFaq), ResourceType = typeof(FaqStrings))]
        [Required(ErrorMessageResourceName = nameof(FaqStrings.TituloFaq), ErrorMessageResourceType = typeof(FaqStrings))]
        public string? Titulo { get; set; }

        [Display(Name = nameof(FaqStrings.Posicion), ResourceType = typeof(FaqStrings))]
        [Required(ErrorMessageResourceName = nameof(FaqStrings.Posicion), ErrorMessageResourceType = typeof(FaqStrings))]
        public int? Posicion { get; set; }

        [Display(Name = nameof(FaqStrings.Descripcion), ResourceType = typeof(FaqStrings))]
        [Required(ErrorMessageResourceName = nameof(FaqStrings.Descripcion), ErrorMessageResourceType = typeof(FaqStrings))]
        public string? Descripcion { get; set; }

        public List<SelectListItem>? Categorias { get; set; }
        public List<SelectListItem>? Paginas { get; set; }
    }
}
