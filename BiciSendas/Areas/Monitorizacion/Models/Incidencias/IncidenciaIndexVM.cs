using BiciSendas.Recursos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Monitorizacion.Models.Incidencias
{
    [Serializable]
    public class IncidenciaIndexVM
    {
        [Display(Name = nameof(IncidenciaStrings.FechaFiltro), ResourceType = typeof(IncidenciaStrings))]
        public DateTime? Fecha { get; set; }

        [Display(Name = nameof(IncidenciaStrings.EstadoFiltro), ResourceType = typeof(IncidenciaStrings))]
        public byte? Estado { get; set; }
        
        [Display(Name = nameof(IncidenciaStrings.BarrioFiltro), ResourceType = typeof(IncidenciaStrings))]
        public int? Barrio { get; set; }
        
        public byte? NumPagina { get; set; }
        public List<IncidenciaGridVM>? Incidencias { get; set; }

        public List<SelectListItem>? Estados { get; set; }
        public List<SelectListItem>? Paginas { get; set; }
    }
}
