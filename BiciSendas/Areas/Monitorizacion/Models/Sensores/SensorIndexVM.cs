using BiciSendas.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;



namespace BiciSendas.Areas.Monitorizacion.Models.Sensores
{
    [Serializable]
    public class SensorIndexVM 
    {

        [Display(Name = nameof(SensorStrings.EstadoSensorFiltro), ResourceType = typeof(SensorStrings))]
        public int? IdEstadoSensor { get; set; }

        [Display(Name = nameof(SensorStrings.TipoSensorfiltro), ResourceType = typeof(SensorStrings))]
        public int? IdTipoSensor { get; set; }

        public List<SelectListItem>? Estados { get; set; }
        public List<SelectListItem>? TipoSensores { get; set; }

        public List<SensorGridVM>? Sensores { get; set; }
    
    }
}
