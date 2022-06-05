using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using Microsoft.EntityFrameworkCore;

namespace BiciSendas.DA
{
    public class IncidenciaDA : BaseRepository<Incidencia>
    {
        private readonly BicisendasContext context;

        public IncidenciaDA(BicisendasContext context) : base(context) 
        {
            this.context = context;   
        }

        /// <summary>
        /// Obtiene todas las incidencias incluyendo tipo de incidencia y estado
        /// </summary>
        /// <returns></returns>
        public override async Task<List<Incidencia>> GetAllAsync()
        {
            return await context
                .Incidencias
                .Include(x=>x.TipoIncidencia)
                .Include(x=>x.Estado)
                .OrderBy(x=>x.Fecha)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas las incidencias según los filtros
        /// </summary>
        /// <param name="filtro">filtros de búsqueda</param>
        /// <returns></returns>
        public async Task<List<Incidencia>> ObtenerFiltrado(IncidenciaFiltro filtro)
        {
            IQueryable<Incidencia> query = context
                .Incidencias
                .Include(x => x.TipoIncidencia)
                .Include(x => x.Estado);

            if (!string.IsNullOrEmpty(filtro.Poblacion))
                query = query.Where(i => i.Poblacion!.ToUpper().Contains(filtro.Poblacion.ToUpper()));

            if (filtro.FechaDesde.HasValue)
                query = query.Where(i => i.Fecha!.Value.Date >= filtro.FechaDesde.Value.Date);

            if(filtro.FechaHasta.HasValue)
                query = query.Where(i => i.Fecha!.Value.Date <= filtro.FechaHasta.Value.Date);

            if (filtro.IdEstado.HasValue)
                query = query.Where(i => i.IdEstado == filtro.IdEstado.Value);

            return await query.OrderBy(i=>i.Fecha).ToListAsync();
        }

        /// <summary>
        /// Obtiene la incidencia con un identificador determinado
        /// incluyendo el tipo de incidencia
        /// </summary>
        /// <param name="id">Identificador de la incidencia</param>
        /// <returns></returns>
        public override async Task<Incidencia?> GetById(int id)
        {
            return await context
                .Incidencias
                .Include(i => i.TipoIncidencia)
                .Where(i => i.IdIncidencia == id)
                .FirstOrDefaultAsync();
        }
    }
}
