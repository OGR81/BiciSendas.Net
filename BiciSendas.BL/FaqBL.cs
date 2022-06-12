using BiciSendas.DA;
using BiciSendas.DA.Entities;
using BiciSendas.Resources;

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

        public async Task<Faq?> ObtenerPorId(int idFaq)
        {
            Faq? faq = await DA.GetById(idFaq);

            if (faq is null)
                throw new Exception($"No se ha encontrado {typeof(Faq)} con Id: " + idFaq);

            return faq;
        }  
        
        public async Task Guardar(Faq faq, bool actualizarPosicion)
        {
            if (faq.IdFaq == 0)
                await DA.Add(faq);
            else
            {
                if(actualizarPosicion)
                {
                    var faqPosicionOriginal = await DA.ObtenerPorPosicion(faq.Posicion!.Value);
                    faqPosicionOriginal.Posicion = null;
                    await DA.Update(faqPosicionOriginal);
                }

                await DA.Update(faq);
            }
        }

        public async Task Eliminar(int idFaq)
        {
            Faq? faq = await DA.GetById(idFaq);

            if (faq is null)
                throw new Exception($"No se ha encontrado {typeof(Faq)} con Id: " + idFaq);

            await DA.Delete(faq);
        }

        public bool ExistePosicion(int idFaq, int posicion)
        {
            return DA.ExistePosicion(idFaq, posicion);
        }

        public List<string> Validar(Faq faq)
        {
            List<string> errores = new();

            if (string.IsNullOrEmpty(faq.Pregunta))
                errores.Add(FaqStrings.ErrorTituloObligatorio);
            else if (faq.Pregunta!.Length > 50)
                errores.Add(FaqStrings.ErrorLongitudTitulo);

            if (string.IsNullOrEmpty(faq.Respuesta))
                errores.Add(FaqStrings.ErrorDescripcionObligatorio);
            else if (faq.Respuesta!.Length > 50)
                errores.Add(FaqStrings.ErrorLongitudDescripcion);

            if (faq.Posicion.HasValue && faq.Posicion.Value > 999999)
                errores.Add(FaqStrings.ErrorValorMaximo);

            return errores;
        }
    }
}

