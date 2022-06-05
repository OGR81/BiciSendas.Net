using BiciSendas.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class EstadoBL
    {
        private readonly EstadoDA DA;
        public EstadoBL(EstadoDA dA)
        {
            DA = dA;
        }

        public async Task<List<Estado>> ObtenerEstados()
        {
            return await DA.GetAllAsync();
        }
    }
}
