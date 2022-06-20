using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class Actuador
    {
        public int IdActuador { get; set; }

        [ForeignKey("IdTipoActuador")]
        public TipoActuador? TipoActuador { get; set; }

        public int IdTipoActuador { get; set; }

        public string? Nombre { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public string? Descripcion { get; set; }
        
    }

    [Serializable]
    public class ActuadorFiltro
    {
        public int? IdTipoActuador { get; set; }
    }
}
