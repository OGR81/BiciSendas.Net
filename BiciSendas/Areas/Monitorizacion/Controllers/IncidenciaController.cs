using BiciSendas.Areas.Monitorizacion.Models.Incidencias;
using BiciSendas.BL;
using BiciSendas.DA;
using BiciSendas.DA.DA;
using BiciSendas.DA.Entities;
using BiciSendas.Views.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BiciSendas.Areas.Monitorizacion.Controllers
{
    [Area("Monitorizacion")]
    public class IncidenciaController : Controller
    {
        private readonly IncidenciaBL IncidenciaBL;
        private readonly EstadoBL EstadoBL;
        private static List<Incidencia> incidencias = new();

        public IncidenciaController(EstadoBL estadoBL, IncidenciaBL incidenciaBL)
        {
            this.EstadoBL = estadoBL;
            this.IncidenciaBL = incidenciaBL;
        }

        public async Task<IActionResult> Index()
        {
            IncidenciaIndexVM model = new();
 
            model.Estados = await ObtenerComboEstados();
            incidencias = await IncidenciaBL.ObtenerIncidencias();

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerIncidencia(int idIncidencia)
        {
            try
            {
                Incidencia? incidencia = await IncidenciaBL.ObtenerPorId(idIncidencia);
                IncidenciaVM? incidenciaVM = MapearIncidenciaToVM(incidencia);

                return Json(incidenciaVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerFiltrado(IncidenciaIndexVM model)
        {
            try
            {
                IncidenciaFiltro filtro = MapearFiltro(model);
                List<Incidencia> incidencias = await IncidenciaBL.ObtenerFiltrado(filtro);

                return Json(new { incidencias });
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

        private static List<IncidenciaGridVM>? MapearIncidenciasToGrid(List<Incidencia> incidencias)
        {
            List<IncidenciaGridVM> model = new List<IncidenciaGridVM>();

            incidencias.ForEach(i =>
            {
                IncidenciaGridVM incidencia = new();
                incidencia.Identificador = i.IdIncidencia;
                incidencia.TipoIncidencia = i.TipoIncidencia?.Nombre;
                incidencia.Poblacion = i.Poblacion;
                incidencia.Direccion = i.Direccion;
                incidencia.FechaIncidencia = i.Fecha;
                incidencia.Estado = i.Estado?.Descripcion;
                incidencia.IdEstado = i.IdEstado;

                model.Add(incidencia);
            });

            return model;
        }

        private async Task<List<SelectListItem>> ObtenerComboEstados()
        {
            List<SelectListItem> combo = new();
            var estados = await EstadoBL.ObtenerEstados();

            combo.Add(new SelectListItem { Value = "-1", Text = "Todos" });

            if(estados.Any())
                estados.ForEach(e => combo.Add(new SelectListItem { Value = e.IdEstado.ToString(), Text = e.Descripcion }));

            return combo.OrderBy(e=>e.Value).ToList();
        }

        private static IncidenciaFiltro MapearFiltro(IncidenciaIndexVM model)
        {
            IncidenciaFiltro filtro = new();
            filtro.Poblacion = model.Poblacion?.Replace("'","´");
            filtro.FechaDesde = model.FechaDesde;
            filtro.FechaHasta = model.FechaHasta;
            filtro.IdEstado = model.Estado < 0 ? null : model.Estado;

            return filtro;
        }

        private static IncidenciaVM MapearIncidenciaToVM(Incidencia? incidencia)
        {
            IncidenciaVM incidenciaVM = new();
            incidenciaVM.TipoIncidencia = incidencia?.TipoIncidencia?.Nombre;
            incidenciaVM.Descripcion = incidencia?.Descripcion;
            incidenciaVM.Fecha = incidencia?.Fecha.ToString();

            if (incidencia?.Foto != null)
            {
                var base64 = Convert.ToBase64String(incidencia.Foto);
                var Image = String.Format("data:image/gif;base64,{0}", base64);
                incidenciaVM.Imagen = Image;
            }
            return incidenciaVM;
        }

        [HttpGet]
        public async Task<PartialViewResult> CargarIncidencias(string filtroIndex)
        {    
            if (!string.IsNullOrEmpty(filtroIndex))
            {
                IncidenciaIndexVM filtroVM = JsonConvert.DeserializeObject<IncidenciaIndexVM>(filtroIndex)!;
                IncidenciaFiltro filtro = MapearFiltro(filtroVM);
                incidencias = await IncidenciaBL.ObtenerFiltrado(filtro);
            }

            List<IncidenciaGridVM>? items = MapearIncidenciasToGrid(incidencias);

            return PartialView("_GridIncidencias", items);
        }
    }
}
