namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqVM
    {
        public int IdFaq { get; set; }
        public string? Pregunta { get; set; }
        public int Posición { get; set; }
        public string? Respuesta { get; set; }        
    }
}
