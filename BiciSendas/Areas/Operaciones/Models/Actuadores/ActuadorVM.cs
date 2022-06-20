using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.Actuadores
{
    [Serializable]
    public class ActuadorVM
    {
        public string? TipoActuador { get; set; }
        public string? Descripcion { get; set; }
        
    }
}
