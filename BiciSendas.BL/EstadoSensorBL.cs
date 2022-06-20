using BiciSendas.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class EstadoSensorBL
    {
        private readonly EstadoSensorDA DA;
        public EstadoSensorBL(EstadoSensorDA dA)
        {
            DA = dA;
        }

        public async Task<List<EstadoSensor>> ObtenerEstados()
        {
            return await DA.GetAllAsync();
        }
    }
}
