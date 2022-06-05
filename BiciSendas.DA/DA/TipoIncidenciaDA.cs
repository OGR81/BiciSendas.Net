using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiciSendas.DA.DA
{
    public class TipoIncidenciaDA : BaseRepository<TipoIncidencia>
    {
        private readonly BicisendasContext context;
        public TipoIncidenciaDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }
    }
}
