using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class EstadoSensor
    {
        public int IdEstadoSensor { get; set; }
        public string? Nombre { get; private set; }

    }
}
