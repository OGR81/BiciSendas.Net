namespace BiciSendas.DA.Entities
{
    [Serializable]
    public class Faq
    {
        public int IdFaq { get; set; }

        public string? Pregunta { get; set; }
        public string? Respuesta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int Posicion { get; set; }       
    } 
}
