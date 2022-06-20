using BiciSendas.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class SensorBL
    {
        private readonly SensorDA DA;
        private List<Sensor> sensores = new();

        public SensorBL(SensorDA da)
        {
            DA = da;
        }

        public async Task<List<Sensor>> ObtenerFiltrado(SensorFiltro filtro)
        {
            return await DA.ObtenerFiltrado(filtro);
        }

        public async Task<List<Sensor>> ObtenerSensores()
        {
            return await DA.GetAllAsync();
        }

        public async Task<Sensor?> ObtenerPorId(int id)
        {
            return await DA.GetById(id);
        }

        public int ObtenerTotalSensores(List<Sensor> sensores)
        {
            return sensores.Count();
        }

        public int ObtenerTotalActivos(List<Sensor> sensores, int idEstadoSen)
        {
            return sensores.Where(es => es.IdEstadoSensor == idEstadoSen).Count();
        }

        public int ObtenerTotalDesactivados(List<Sensor> sensores, int idEstadoSen)
        {
            return sensores.Where(es => es.IdEstadoSensor == idEstadoSen).Count();
        }
    }
}

