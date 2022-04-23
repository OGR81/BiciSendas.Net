using BiciSendas.Recursos;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Actuadores
{
    [Serializable]
    public class ActuadorGridVM
    {
        [Display(Name = nameof(ActuadorStrings.Identificador), ResourceType = typeof(ActuadorStrings))]
        public string? Identificador { get; set; }

        [Display(Name = nameof(ActuadorStrings.Nombre), ResourceType = typeof(ActuadorStrings))]
        public string? Nombre { get; set; }
        [Display(Name = nameof(ActuadorStrings.TipoActuador), ResourceType = typeof(ActuadorStrings))]
        public int? TipoActuador { get; set; }
        [Display(Name = nameof(ActuadorStrings.FechaModificacion), ResourceType = typeof(ActuadorStrings))]
        public int? FechaModificacion { get; set; }
        [Display(Name = nameof(ActuadorStrings.Opciones), ResourceType = typeof(ActuadorStrings))]
        public string? Opciones { get; set; }
        
    }
}
