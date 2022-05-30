using BiciSendas.DA.Entities;
using BiciSendas.DA.Repository;

namespace BiciSendas.DA
{
    public class EstadoDA : BaseRepository<Estado>
    {
        private readonly BicisendasContext context;
        public EstadoDA(BicisendasContext context) : base(context)
        {
            this.context = context;
        }
    }
}