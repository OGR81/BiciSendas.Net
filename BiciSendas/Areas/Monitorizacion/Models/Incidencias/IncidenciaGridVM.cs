using BiciSendas.Recursos;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Monitorizacion.Models.Incidencias
{
    [Serializable]
    public class IncidenciaGridVM
    {
        [Display(Name = nameof(IncidenciaStrings.Identificador), ResourceType = typeof(IncidenciaStrings))]
        public string? Identificador { get; set; }

        [Display(Name = nameof(IncidenciaStrings.Nombre), ResourceType = typeof(IncidenciaStrings))]
        public string? Nombre { get; set; }
        [Display(Name = nameof(IncidenciaStrings.Usuario), ResourceType = typeof(IncidenciaStrings))]
        public int? Usuario { get; set; }
        [Display(Name = nameof(IncidenciaStrings.Barrio), ResourceType = typeof(IncidenciaStrings))]
        public int? Barrio { get; set; }
        [Display(Name = nameof(IncidenciaStrings.Coordenadas), ResourceType = typeof(IncidenciaStrings))]
        public string? Coordenadas { get; set; }
        [Display(Name = nameof(IncidenciaStrings.FechaIncidencia), ResourceType = typeof(IncidenciaStrings))]
        public DateTime? FechaIncidencia { get; set; }
        [Display(Name = nameof(IncidenciaStrings.Estado), ResourceType = typeof(IncidenciaStrings))]
        public byte? Estado { get; set; }
    }
}
