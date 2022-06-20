using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Monitorizacion.Models.Sensores
{
    [Serializable]
    public class SensorGridVM
    {
        
        [Display(Name = nameof(SensorStrings.Identificador), ResourceType = typeof(SensorStrings))]
        public int Identificador { get; set; }

        [Display(Name = nameof(SensorStrings.TipoSensor), ResourceType = typeof(SensorStrings))]
        public string? TipoSensor { get; set; }

        [Display(Name = nameof(SensorStrings.EstadoSensor), ResourceType = typeof(SensorStrings))]
        public string? Estado { get; set; }
        [Display(Name = nameof(SensorStrings.Poblacion), ResourceType = typeof(SensorStrings))]
        public string? Poblacion { get; set; }
        [Display(Name = nameof(SensorStrings.Direccion), ResourceType = typeof(SensorStrings))]
        public string? Direccion { get; set; }
        [Display(Name = nameof(SensorStrings.FechaModificacion), ResourceType = typeof(SensorStrings))]
        public DateTime? FechaModificacion { get; set; }

        public int IdEstadoSensor { get; set; }

        public int IdTipoSensor { get; set; }
        
    }
}
