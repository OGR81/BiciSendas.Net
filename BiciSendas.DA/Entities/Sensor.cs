using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class Sensor
    {
        public int IdSensor { get; set; }

        [ForeignKey("IdTipoSensor")]
        public TipoSensor? TipoSensor { get; set; }

        public int? IdTipoSensor { get; set; }
        public int IdEstadoSensor { get; set; }

        [ForeignKey("IdEstadoSensor")]
        public EstadoSensor? EstadoSensor { get; set; }

        public string? Poblacion { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        
    }
    [Serializable]
    public class SensorFiltro
    {
        public int? IdTipoSensor { get; set; }
        
        public int? IdEstado { get; set; }
    }
}
