using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class Sensor : BaseEntity
    {
        public string? Nombre { get; set; }   
        public int? Estado { get; set; }
        public int? Categoria { get; set; }
        public string? Coordenadas { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? Identificador { get; set; }
    }
}
