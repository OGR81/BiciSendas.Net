using BiciSendas.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Monitorizacion.Models.Incidencias
{
    [Serializable]
    public class IncidenciaIndexVM
    {
        [Display(Name = nameof(IncidenciaStrings.FechaDesdeFiltro), ResourceType = typeof(IncidenciaStrings))]
        public DateTime? FechaDesde { get; set; }

        [Display(Name = nameof(IncidenciaStrings.FechaHastaFiltro), ResourceType = typeof(IncidenciaStrings))]
        public DateTime? FechaHasta { get; set; }

        [Display(Name = nameof(IncidenciaStrings.EstadoFiltro), ResourceType = typeof(IncidenciaStrings))]
        public int? Estado { get; set; }
        
        [Display(Name = nameof(IncidenciaStrings.PoblacionFiltro), ResourceType = typeof(IncidenciaStrings))]
        public string? Poblacion { get; set; }

        public List<SelectListItem>? Estados { get; set; }
        public List<IncidenciaGridVM>? Incidencias { get; set; }
    }
}
