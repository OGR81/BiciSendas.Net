using BiciSendas.Areas.Monitorizacion.Models.Sensores;
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
    public class SensorController : Controller
    {

        private readonly SensorBL SensorBL;
        private readonly EstadoSensorBL EstadoSensorBL;
        private readonly TipoSensorBL TipoSensorBL;
        private static List<Sensor> sensores = new();

        public SensorController(EstadoSensorBL estadoSensorBL, SensorBL sensorBL, TipoSensorBL tipoSensorBL)
        {
            this.EstadoSensorBL = estadoSensorBL;
            this.SensorBL = sensorBL;
            this.TipoSensorBL = tipoSensorBL;
        }

        public async Task<IActionResult> Index()
        {
            SensorIndexVM model = new();

            model.Estados = await ObtenerComboEstados();
            sensores = await SensorBL.ObtenerSensores();
            model.TipoSensores = await ObtenerComboTipoSensor();
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerSensor(int idSensor)
        {
            try
            {
                Sensor? sensor = await SensorBL.ObtenerPorId(idSensor);
                SensorVM? sensorVM = MapearSensorToVM(sensor);

                return Json(sensorVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
        [HttpGet]
        public async Task<JsonResult> ObtenerFiltrado(SensorIndexVM model)
        {
            try
            {
                SensorFiltro filtro = MapearFiltro(model);
                List<Sensor> sensores = await SensorBL.ObtenerFiltrado(filtro);

                return Json(new { sensores });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        private static List<SensorGridVM>? MapearSensoresToGrid(List<Sensor> sensores)
        {
            List<SensorGridVM> model = new List<SensorGridVM>();

            sensores.ForEach(i =>
            {
                SensorGridVM sensor = new();
                sensor.Identificador = i.IdSensor;
                sensor.TipoSensor = i.TipoSensor?.Nombre;
                sensor.Poblacion = i.Poblacion;
                sensor.Direccion = i.Direccion;
                sensor.FechaModificacion = i.FechaModificacion;
                sensor.Estado = i.EstadoSensor?.Nombre;
                sensor.IdEstadoSensor = i.IdEstadoSensor;
                
                model.Add(sensor);
            });

            return model;
        }

        private async Task<List<SelectListItem>> ObtenerComboEstados()
        {
            List<SelectListItem> combo = new();
            var estados = await EstadoSensorBL.ObtenerEstados();

            combo.Add(new SelectListItem { Value = "-1", Text = "Todos" });

            estados.ForEach(e => combo.Add(new SelectListItem { Value = e.IdEstadoSensor.ToString(), Text = e.Nombre }));

            return combo.OrderBy(e => e.Value).ToList();
        }
        private async Task<List<SelectListItem>> ObtenerComboTipoSensor()
        {
            List<SelectListItem> combo = new();
            var estados = await TipoSensorBL.ObtenerTiposSensores();

            combo.Add(new SelectListItem { Value = "-1", Text = "Todos" });

            estados.ForEach(e => combo.Add(new SelectListItem { Value = e.IdTipoSensor.ToString(), Text = e.Nombre }));

            return combo.OrderBy(e => e.Value).ToList();
        }

        private static SensorFiltro MapearFiltro(SensorIndexVM model)
        {
            SensorFiltro filtro = new();
            filtro.IdTipoSensor = model.IdTipoSensor < 0 ? null : model.IdTipoSensor;
            filtro.IdEstado = model.IdEstadoSensor < 0 ? null : model.IdEstadoSensor;

            return filtro;
        }

        private static SensorVM MapearSensorToVM(Sensor? sensor)
        {
            SensorVM sensorVM = new();
            //sensorVM.TipoSensor = sensor?.TipoSensor?.Nombre;
            //sensorVM.Descripcion = sensor?.Descripcion;
            //sensorVM.Fecha = sensor?.FechaModificacion.ToString();

            return sensorVM;
        }

        [HttpGet]
        public async Task<PartialViewResult> CargarSensores(string filtroIndex)
        {
            if (!string.IsNullOrEmpty(filtroIndex))
            {
                SensorIndexVM filtroVM = JsonConvert.DeserializeObject<SensorIndexVM>(filtroIndex)!;
                SensorFiltro filtro = MapearFiltro(filtroVM);
                sensores = await SensorBL.ObtenerFiltrado(filtro);
            }

            List<SensorGridVM>? items = MapearSensoresToGrid(sensores);

            return PartialView("_GridSensores", items);
        }
    }
}
