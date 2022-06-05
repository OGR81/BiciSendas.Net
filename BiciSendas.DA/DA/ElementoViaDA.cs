using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;

namespace BiciSendas.DA
{
    public class ElementoViaDA : BaseRepository<ElementoVia>
    {
        public readonly BicisendasContext context;

        public ElementoViaDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Comprueba si ya existe un elemento vía con el mismo nombre
        /// </summary>
        /// <param name="elementoVia"></param>
        /// <returns></returns>
        public bool YaExisteNombre(ElementoVia elementoVia)
        {
            return context.ElementosVias
                .Where(ev => ev.Nombre!.ToUpper() == elementoVia.Nombre!.ToUpper())
                .Where(ev => ev.IdElementoVia != elementoVia.IdElementoVia)
                .Any();
        }

        /// <summary>
        /// Comprueba si ya existe un elemento vía con el mismo identificador
        /// </summary>
        /// <param name="elementoVia"></param>
        /// <returns></returns>
        public bool YaExisteIdentificador(ElementoVia elementoVia)
        {
            return context.ElementosVias
                .Where(ev => ev.Identificador!.ToUpper() == elementoVia.Identificador!.ToUpper())
                .Where(ev => ev.IdElementoVia != elementoVia.IdElementoVia)
                .Any();
        }
    }
}
