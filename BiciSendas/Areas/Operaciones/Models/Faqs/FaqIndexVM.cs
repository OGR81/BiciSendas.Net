using BiciSendas.Recursos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqIndexVM
    {
        public byte? NumPagina { get; set; }
        public List<FaqGridVM>? Actuadores { get; set; }

        public List<SelectListItem>? Categorias { get; set; }
        public List<SelectListItem>? Paginas { get; set; }
    }
}
