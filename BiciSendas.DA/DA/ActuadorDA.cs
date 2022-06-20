using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using Microsoft.EntityFrameworkCore;

namespace BiciSendas.DA
{
    public class ActuadorDA : BaseRepository<Actuador>
    {
        private readonly BicisendasContext context;

        public ActuadorDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todas los actuadores incluyendo tipo de actuador
        /// </summary>
        /// <returns></returns>
        public override async Task<List<Actuador>> GetAllAsync()
        {
            return await context
                .Actuadores
                .Include(x => x.TipoActuador)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas los actuadores según filtro
        /// </summary>
        /// <param name="filtro">filtros de búsqueda</param>
        /// <returns></returns>
        public async Task<List<Actuador>> ObtenerFiltrado(ActuadorFiltro filtro)
        {
            IQueryable<Actuador> query = context
                .Actuadores
                .Include(x => x.TipoActuador);
                
            if (filtro.IdTipoActuador.HasValue)
                query = query.Where(ta => ta.IdTipoActuador == filtro.IdTipoActuador.Value);

            return await query.ToListAsync();

        }

        /// <summary>
        /// Obtiene el actuador con un identificador determinado
        /// incluyendo el tipo de actuador
        /// </summary>
        /// <param name="id">Identificador del actuador</param>
        /// <returns></returns>
        public override async Task<Actuador?> GetById(int id)
        {
            return await context
                .Actuadores
                .Include(ta => ta.TipoActuador)
                .FirstOrDefaultAsync();
        }
    }
}
