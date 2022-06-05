using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiciSendas.Views.Utils
{
    public static class Combos
    {
        private static int[] numRegistros = new int[] {10,20,30};
        
        public static List<SelectListItem> ComboNumRegistros()
        {
            List<SelectListItem> items = new();

            numRegistros.ToList().ForEach(x => items.Add(new SelectListItem() { Value = x.ToString(), Text = x.ToString() }));

            return items;
        }
 
    }
}
