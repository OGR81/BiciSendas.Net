namespace BiciSendas.Areas.Monitorizacion.Models.Incidencias
{
    [Serializable]
    public class IncidenciaVM
    {
        public string? TipoIncidencia { get; set; }
        public string? Fecha { get; set; }
        public string? Descripcion { get; set; }
        public string? Imagen { get; set; }
    }
}
