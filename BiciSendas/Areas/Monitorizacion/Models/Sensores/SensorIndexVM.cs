using BiciSendas.Recursos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace BiciSendas.Areas.Monitorizacion.Models.Sensores
{
    [Serializable]
    public class SensorIndexVM
    {
        public int? NumPagina { get; set; }

        [Display(Name = nameof(SensorStrings.Categoria), ResourceType = typeof(SensorStrings))]
        public int? Categoria { get; set; }
        public List<SensorGridVM>? Sensores { get; set; }

        public List<SelectListItem>? Categorias { get; set; }
        public List<SelectListItem>? Paginas { get; set; }
    }
}
