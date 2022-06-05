using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class ElementoVia
    {
        public int IdElementoVia { get; set; }
        public string? Nombre { get; set; }
        public string? TipoElemento { get; set; }
        public string? Identificador { get; set; }
    }
}
