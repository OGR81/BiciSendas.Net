using BiciSendas.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class FaqBL
    {
        private readonly FaqDA DA;

        public FaqBL(FaqDA da)
        {
            DA = da;
        }

        public async Task<List<Faq>> ObtenerFaqs()
        {
            return await DA.GetAllAsync();
        }

        public async Task<Faq?> ObtenerPorId(int id)
        {
            return await DA.GetById(id);
        }  
        
        public async Task Guardar(Faq faq)
        {
            if (faq.IdFaq == 0)
                await DA.Add(faq);
            else
                await DA.Update(faq);
        }
    }
}

