using BiciSendas.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Actuadores
{
    [Serializable]
    public class ActuadorIndexVM
    {       
        [Display(Name = nameof(ActuadorStrings.TipoActuadorFiltro), ResourceType = typeof(ActuadorStrings))]
        public int? IdTipoActuador { get; set; }
        public List<SelectListItem>? TipoActuadores { get; set; }
        public List<ActuadorGridVM>? Actuadores { get; set; }

    }
}
