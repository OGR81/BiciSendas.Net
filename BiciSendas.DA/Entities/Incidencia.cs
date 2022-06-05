using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class Incidencia
    {
        public int IdIncidencia { get; set; }

        [ForeignKey("IdTipoIncidencia")]
        public TipoIncidencia? TipoIncidencia { get; set; }
        
        public int IdTipoIncidencia { get; set; }
        
        public string? Poblacion { get; set; }
        
        public string? Direccion { get; set; }
        
        public DateTime? Fecha { get; set; }
        
        public int IdEstado { get; set; }

        [ForeignKey("IdEstado")]
        public Estado? Estado { get; set; }

        public string? Descripcion { get; set; }
        public byte[]? Foto { get; set; }
    }

    [Serializable]
    public class IncidenciaFiltro 
    { 
        public string? Poblacion { get; set; }
        public DateTime? FechaDesde { get; set; }
        public DateTime? FechaHasta { get; set; }
        public int? IdEstado { get; set; }
    }
}
