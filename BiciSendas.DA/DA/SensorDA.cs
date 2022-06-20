using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using Microsoft.EntityFrameworkCore;

namespace BiciSendas.DA
{
    public class SensorDA : BaseRepository<Sensor>
    {
        private readonly BicisendasContext context;

        public SensorDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todos los sensores incluyendo tipo de sensor y estado
        /// </summary>
        /// <returns></returns>
        public override async Task<List<Sensor>> GetAllAsync()
        {
            return await context
                .Sensores
                .Include(x => x.TipoSensor)
                .Include(x => x.EstadoSensor)
                .ToListAsync();
        }

        /// <summary>
        /// Obtiene todas l0o sensores según los filtros
        /// </summary>
        /// <param name="filtro">filtros de búsqueda</param>
        /// <returns></returns>
        public async Task<List<Sensor>> ObtenerFiltrado(SensorFiltro filtro)
        {
            IQueryable<Sensor> query = context
                .Sensores
                .Include(x => x.TipoSensor)
                .Include(x => x.EstadoSensor);

            if (filtro.IdTipoSensor.HasValue)
                query = query.Where(s => s.IdTipoSensor == filtro.IdTipoSensor.Value);


            if (filtro.IdEstado.HasValue)
                query = query.Where(s => s.IdEstadoSensor == filtro.IdEstado.Value);

            return await query.ToListAsync();

        }

        /// <summary>
        /// Obtiene el sensor con un identificador determinado
        /// incluyendo el tipo de sensor
        /// </summary>
        /// <param name="id">Identificador del sensor</param>
        /// <returns></returns>
        public override async Task<Sensor?> GetById(int id)
        {
            return await context
                .Sensores
                .Include(s => s.IdTipoSensor)
                .Where(s => s.IdSensor == id)
                .FirstOrDefaultAsync();
        }
    }
}
