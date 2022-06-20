using BiciSendas.Areas.Operaciones.Models.Actuadores;
using BiciSendas.BL;
using BiciSendas.DA;
using BiciSendas.DA.DA;
using BiciSendas.DA.Entities;
using BiciSendas.Views.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BiciSendas.Areas.Operaciones.Controllers
{
    [Area("Operaciones")]
    public class ActuadorController : Controller
    {
        private readonly ActuadorBL ActuadorBL;
        private static List<Actuador> actuadores = new();
        private readonly TipoActuadorBL TipoActuadorBL;
        public ActuadorController(TipoActuadorBL tipoActuadorBL, ActuadorBL actuadorBL)
        {
            this.TipoActuadorBL = tipoActuadorBL;
            this.ActuadorBL = actuadorBL;
        }

        public async Task<IActionResult> Index()
        {
            ActuadorIndexVM model = new();

            model.TipoActuadores = await ObtenerComboTipoActuador();
            actuadores = await ActuadorBL.ObtenerActuadores();

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerActuador(int idActuador)
        {
            try
            {
                Actuador? actuador = await ActuadorBL.ObtenerPorId(idActuador);
                ActuadorVM? actuadorVM = MapearActuadorToVM(actuador);

                return Json(actuadorVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerFiltrado(ActuadorIndexVM model)
        {
            try
            {
                ActuadorFiltro filtro = MapearFiltro(model);
                List<Actuador> actuadores = await ActuadorBL.ObtenerFiltrado(filtro);

                return Json(new { actuadores });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        private static List<ActuadorGridVM>? MapearActuadoresToGrid(List<Actuador> actuadores)
        {
            List<ActuadorGridVM> model = new();

            actuadores.ForEach(i =>
            {
                ActuadorGridVM actuador = new();
                actuador.Identificador = i.IdActuador;
                actuador.Nombre = i.Nombre;
                actuador.TipoActuador = i.TipoActuador?.Nombre;
                actuador.FechaModificacion = i.FechaModificacion;
                
                model.Add(actuador);
            });

            return model;
        }

        private async Task<List<SelectListItem>> ObtenerComboTipoActuador()
        {
            List<SelectListItem> combo = new();
            var estados = await TipoActuadorBL.ObtenerTiposActuadores();

            combo.Add(new SelectListItem { Value = "-1", Text = "Todos" });

            if(estados.Any())
                estados.ForEach(ta => combo.Add(new SelectListItem { Value = ta.IdTipoActuador.ToString(), Text = ta.Nombre }));

            return combo.OrderBy(ta => ta.Value).ToList();
        }

        private static ActuadorFiltro MapearFiltro(ActuadorIndexVM model)
        {
            ActuadorFiltro filtro = new();
            filtro.IdTipoActuador = model.IdTipoActuador < 0 ? null : model.IdTipoActuador;

            return filtro;
        }

        private static ActuadorVM MapearActuadorToVM(Actuador? actuador)
        {
            ActuadorVM actuadorVM = new();
            actuadorVM.TipoActuador = actuador?.TipoActuador?.Nombre;
            actuadorVM.Descripcion = actuador?.Descripcion;
            
            return actuadorVM;
        }

        [HttpGet]
        public async Task<PartialViewResult> CargarActuadores(string filtroIndex)
        {
            if (!string.IsNullOrEmpty(filtroIndex))
            {
                ActuadorIndexVM filtroVM = JsonConvert.DeserializeObject<ActuadorIndexVM>(filtroIndex)!;
                ActuadorFiltro filtro = MapearFiltro(filtroVM);
                actuadores = await ActuadorBL.ObtenerFiltrado(filtro);
            }

            List<ActuadorGridVM>? items = MapearActuadoresToGrid(actuadores);

            return PartialView("_GridActuadores", items);
        }
    }
}
