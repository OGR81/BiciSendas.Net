using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;

namespace BiciSendas.DA
{
    public class EstadoSensorDA : BaseRepository<EstadoSensor>
    {
        private readonly BicisendasContext context;
        public EstadoSensorDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }
    }
}
