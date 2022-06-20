using BiciSendas.DA;
using BiciSendas.DA.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class TipoActuadorBL
    {
        private readonly TipoActuadorDA DA;
        public TipoActuadorBL(TipoActuadorDA dA)
        {
            DA = dA;
        }

        public async Task<List<TipoActuador>> ObtenerTiposActuadores()
        {
            return await DA.GetAllAsync();
        }
    }
}
