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

        public IActionResult Index()
        {
            IncidenciaIndexVM model = new();
 
            model.Estados = ObtenerComboEstados();
            incidencias = IncidenciaBL.ObtenerIncidencias().Result;

            return View(model);
        }

        [HttpGet]
        public JsonResult ObtenerIncidencia(int idIncidencia)
        {
            try
            {
                Incidencia? incidencia = IncidenciaBL.ObtenerPorId(idIncidencia).Result;
                IncidenciaVM? incidenciaVM = MapearIncidenciaToVM(incidencia);

                return Json(incidenciaVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public JsonResult ObtenerFiltrado(IncidenciaIndexVM model)
        {
            try
            {
                IncidenciaFiltro filtro = MapearFiltro(model);
                List<Incidencia> incidencias = IncidenciaBL.ObtenerFiltrado(filtro).Result;

                return Json(new { incidencias = incidencias});
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

        private List<IncidenciaGridVM>? MapearIncidenciasToVM(List<Incidencia> incidencias)
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

        private List<SelectListItem> ObtenerComboEstados()
        {
            List<SelectListItem> combo = new();
            var estados = EstadoBL.ObtenerEstados().Result;

            combo.Add(new SelectListItem { Value = "-1", Text = "Todos" });

            estados.ForEach(e => combo.Add(new SelectListItem { Value = e.IdEstado.ToString(), Text = e.Descripcion }));

            return combo.OrderBy(e=>e.Value).ToList();
        }

        private IncidenciaFiltro MapearFiltro(IncidenciaIndexVM model)
        {
            IncidenciaFiltro filtro = new();
            filtro.Poblacion = model.Poblacion?.Replace("'","´");
            filtro.FechaDesde = model.FechaDesde;
            filtro.FechaHasta = model.FechaHasta;
            filtro.IdEstado = model.Estado < 0 ? null : model.Estado;

            return filtro;
        }

        private IncidenciaVM MapearIncidenciaToVM(Incidencia? incidencia)
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
        public PartialViewResult CargarIncidencias(string filtroIndex)
        {
            IncidenciaIndexVM filtroVM = new();

            if (!string.IsNullOrEmpty(filtroIndex))
            {
                filtroVM = JsonConvert.DeserializeObject<IncidenciaIndexVM>(filtroIndex)!;
                IncidenciaFiltro filtro = MapearFiltro(filtroVM);
                incidencias = IncidenciaBL.ObtenerFiltrado(filtro).Result;
            }

            List<IncidenciaGridVM>? items = MapearIncidenciasToVM(incidencias);

            return PartialView("_GridIncidencias", items);
        }
    }
}
