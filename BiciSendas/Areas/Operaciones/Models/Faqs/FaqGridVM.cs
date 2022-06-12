using BiciSendas.Resources;
using System.ComponentModel.DataAnnotations;

namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqGridVM
    {
        [Display(Name = nameof(FaqStrings.IdentificadorGrid), ResourceType = typeof(FaqStrings))]
        public int Identificador { get; set; }

        [Display(Name = nameof(FaqStrings.PreguntasFrecuentesGrid), ResourceType = typeof(FaqStrings))]
        public string? Pregunta { get; set; }
        
        [Display(Name = nameof(FaqStrings.RespuestasGrid), ResourceType = typeof(FaqStrings))]
        public string? Respuesta { get; set; }

        [Display(Name = nameof(FaqStrings.FechaModificacionGrid), ResourceType = typeof(FaqStrings))]
        public DateTime? FechaModificacion { get; set; }

        [Display(Name = nameof(FaqStrings.FechaAltaGrid), ResourceType = typeof(FaqStrings))]
        public DateTime FechaAlta { get; set; }
        
        [Display(Name = nameof(FaqStrings.PosicionGrid), ResourceType = typeof(FaqStrings))]
        public int? Posicion { get; set; }

    }
}
