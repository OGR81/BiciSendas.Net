using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;


namespace BiciSendas.DA.DA
{
    public class TipoActuadorDA : BaseRepository<TipoActuador>
    {
        private readonly BicisendasContext context;
        public TipoActuadorDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }
    }
}
