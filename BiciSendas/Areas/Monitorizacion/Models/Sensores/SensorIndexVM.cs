using BiciSendas.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace BiciSendas.Areas.Monitorizacion.Models.Sensores
{
    [Serializable]
    public class SensorIndexVM
    {
        [Display(Name = nameof(SensorStrings.Categoria), ResourceType = typeof(SensorStrings))]
        public int? Categoria { get; set; }
        public List<SensorGridVM>? Sensores { get; set; }

        public List<SelectListItem>? Categorias { get; set; }
    }
}
