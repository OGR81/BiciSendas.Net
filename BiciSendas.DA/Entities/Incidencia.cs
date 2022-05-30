using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class Incidencia : BaseEntity
    {
        public TipoIncidencia? TipoIncidencia { get; set; }
        public short IdTipoIncidencia { get; set; }
        public string? Poblacion { get; set; }
        public string? Direccion { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public DateTime Fecha { get; set; }
        public short IdEstado { get; set; }
        public Estado? Estado { get; set; }
    }
}
