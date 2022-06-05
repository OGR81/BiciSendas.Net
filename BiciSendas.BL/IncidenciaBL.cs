using BiciSendas.DA;
using BiciSendas.DA.Entities;

namespace BiciSendas.BL
{
    public class IncidenciaBL
    {
        private readonly IncidenciaDA DA;
        private List<Incidencia> incidencias = new();

        public IncidenciaBL(IncidenciaDA da) 
        {
            DA = da;
        }

        public async Task<List<Incidencia>> ObtenerFiltrado(IncidenciaFiltro filtro)
        {
            return await DA.ObtenerFiltrado(filtro);
        }

        public async Task<List<Incidencia>> ObtenerIncidencias()
        {
            return await DA.GetAllAsync();
        }

        public async Task<Incidencia?> ObtenerPorId(int id)
        {
            return await DA.GetById(id);
        }

        public int ObtenerTotalIncidencias(List<Incidencia> incidencias)
        {
            return incidencias.Count();
        }

        public int ObtenerTotalCaidas(List<Incidencia> incidencias, int idTipoIncidencia)
        {
            return incidencias.Where(i => i.IdTipoIncidencia == idTipoIncidencia).Count();
        }

        public int ObtenerTotalPendientes(List<Incidencia> incidencias, int idEstado)
        {
            return incidencias.Where(i => i.IdEstado == idEstado).Count();
        }

        public int ObtenerTotalResueltas(List<Incidencia> incidencias, int idEstado)
        {
            return incidencias.Where(i => i.IdEstado == idEstado).Count();
        }
    }
}
