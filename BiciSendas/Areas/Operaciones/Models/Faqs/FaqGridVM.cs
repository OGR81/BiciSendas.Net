using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqGridVM
    {
        [Display(Name = nameof(FaqStrings.Identificador), ResourceType = typeof(FaqStrings))]
        public int Identificador { get; set; }

        [Display(Name = nameof(FaqStrings.PreguntasFrecuentes), ResourceType = typeof(FaqStrings))]
        public string? Pregunta { get; set; }
        
        [Display(Name = nameof(FaqStrings.Respuestas), ResourceType = typeof(FaqStrings))]
        public string? Respuesta { get; set; }

        [Display(Name = nameof(FaqStrings.FechaModificacion), ResourceType = typeof(FaqStrings))]
        public DateTime? FechaModificacion { get; set; }

        [Display(Name = nameof(FaqStrings.FechaAlta), ResourceType = typeof(FaqStrings))]
        public DateTime FechaAlta { get; set; }
        
        [Display(Name = nameof(FaqStrings.Posicion), ResourceType = typeof(FaqStrings))]
        public int Posicion { get; set; }

    }
}
