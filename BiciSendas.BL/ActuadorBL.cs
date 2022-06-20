using BiciSendas.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class ActuadorBL
    {
        private readonly ActuadorDA DA;
        private List<Actuador> actuadores = new();

        public ActuadorBL(ActuadorDA da)
        {
            DA = da;
        }

        public async Task<List<Actuador>> ObtenerFiltrado(ActuadorFiltro filtro)
        {
            return await DA.ObtenerFiltrado(filtro);
        }

        public async Task<List<Actuador>> ObtenerActuadores()
        {
            return await DA.GetAllAsync();
        }

        public async Task<Actuador?> ObtenerPorId(int id)
        {
            return await DA.GetById(id);
        }

        public int ObtenerTotalActuadores(List<Actuador> actuadores)
        {
            return actuadores.Count();
        }

        public int ObtenerTotalTipos(List<Actuador> actuadores, int idTipoActuador)
        {
            return actuadores.Where(ta => ta.IdTipoActuador == idTipoActuador).Count();
        }

    }
}
