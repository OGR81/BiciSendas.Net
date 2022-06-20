using BiciSendas.DA.DA;
using BiciSendas.DA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.BL
{
    public class TipoSensorBL
    {
        private readonly TipoSensorDA DA;
        public TipoSensorBL(TipoSensorDA da)
        {
            DA = da;
        }

        public async Task<List<TipoSensor>> ObtenerTiposSensores()
        {
            return await DA.GetAllAsync();
        }
    }
}
