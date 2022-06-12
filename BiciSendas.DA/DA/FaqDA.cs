using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using Microsoft.EntityFrameworkCore;

namespace BiciSendas.DA
{
    public class FaqDA : BaseRepository<Faq>
    {
        private readonly BicisendasContext context;

        public FaqDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Comprueba si ya existe alguna pregunta con la misma posición
        /// </summary>
        /// <param name="idFaq">Identificador de la pregunta</param>
        /// <param name="posicion">Posición de la pregunta a comprobar</param>
        /// <returns></returns>
        public bool ExistePosicion(int idFaq, int posicion)
        {
            return
                context.Faqs
                .Where(f => f.Posicion == posicion)
                .Where(f => f.IdFaq != idFaq)
                .Any();
        }

        /// <summary>
        /// Obtenemos la faq con una posición determinada
        /// </summary>
        /// <param name="posicion">posición</param>
        /// <returns></returns>
        public Task<Faq> ObtenerPorPosicion(int posicion)
        {
            return
                context.Faqs
                .Where(f => f.Posicion!.Value == posicion)
                .FirstAsync();
        }
    }
}
