using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.DA
{
    public class TipoSensorDA : BaseRepository<TipoSensor>
    {
        private readonly BicisendasContext context;
        public TipoSensorDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }
    }
}
