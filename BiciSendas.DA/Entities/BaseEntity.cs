using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class BaseEntity
    {
        public int? Id { get; set; }
        public string? Identificador { get; set; }
        public string? Nombre { get; set; }
    }
}
