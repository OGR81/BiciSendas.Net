using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Monitorizacion.Models.Incidencias
{
    [Serializable]
    public class IncidenciaGridVM
    {
        [Display(Name = nameof(IncidenciaStrings.Identificador), ResourceType = typeof(IncidenciaStrings))]
        public int Identificador { get; set; }

        [Display(Name = nameof(IncidenciaStrings.TipoIncidencia), ResourceType = typeof(IncidenciaStrings))]
        public string? TipoIncidencia { get; set; }

        [Display(Name = nameof(IncidenciaStrings.Poblacion), ResourceType = typeof(IncidenciaStrings))]
        public string? Poblacion { get; set; }

        [Display(Name = nameof(IncidenciaStrings.Direccion), ResourceType = typeof(IncidenciaStrings))]
        public string? Direccion { get; set; }

        [Display(Name = nameof(IncidenciaStrings.FechaIncidencia), ResourceType = typeof(IncidenciaStrings))]
        public DateTime? FechaIncidencia { get; set; }

        [Display(Name = nameof(IncidenciaStrings.Estado), ResourceType = typeof(IncidenciaStrings))]
        public string? Estado { get; set; }

        public int IdEstado { get; set; }
    }
}
