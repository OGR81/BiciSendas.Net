using BiciSendas.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace BiciSendas.Areas.Operaciones.Models.Faqs
{
    [Serializable]
    public class FaqIndexVM
    {
        public List<FaqGridVM>? Faqs { get; set; }

        public FaqVM FaqVM { get; set; } = new();  
    }
        
}
