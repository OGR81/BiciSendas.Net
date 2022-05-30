using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class TipoIncidencia: BaseEntity
    {
        public string? Nombre { get; }
    }
}
