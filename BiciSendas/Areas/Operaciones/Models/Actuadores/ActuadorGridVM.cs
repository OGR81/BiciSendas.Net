using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Actuadores
{
    [Serializable]
    public class ActuadorGridVM
    {
        [Display(Name = nameof(ActuadorStrings.Identificador), ResourceType = typeof(ActuadorStrings))]
        public int Identificador { get; set; }

        [Display(Name = nameof(ActuadorStrings.Nombre), ResourceType = typeof(ActuadorStrings))]
        public string? Nombre { get; set; }
        [Display(Name = nameof(ActuadorStrings.TipoActuador), ResourceType = typeof(ActuadorStrings))]
        public string? TipoActuador { get; set; }
        [Display(Name = nameof(ActuadorStrings.FechaModificacion), ResourceType = typeof(ActuadorStrings))]
        public DateTime? FechaModificacion { get; set; }
        [Display(Name = nameof(ActuadorStrings.Opciones), ResourceType = typeof(ActuadorStrings))]
        public string? Opciones { get; set; }
        
    }
}
