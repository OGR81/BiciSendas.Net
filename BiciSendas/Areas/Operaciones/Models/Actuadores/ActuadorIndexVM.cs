using BiciSendas.Recursos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Actuadores
{
    [Serializable]
    public class ActuadorIndexVM
    {       
        public byte? NumPagina { get; set; }
        public List<ActuadorGridVM>? Actuadores { get; set; }

        public List<SelectListItem>? TipoActuador { get; set; }
        public List<SelectListItem>? Paginas { get; set; }

    }
}
