using BiciSendas.Areas.Monitorizacion.Models.Incidencias;
using BiciSendas.DA;
using BiciSendas.DA.DA;
using BiciSendas.DA.Entities;
using BiciSendas.Views.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiciSendas.Areas.Monitorizacion.Controllers
{
    [Area("Monitorizacion")]
    public class IncidenciaController : Controller
    {
        private readonly IncidenciaDA IncidenciaDA;
        private readonly EstadoDA EstadoDA;

        public IncidenciaController(IncidenciaDA incidenciaDA, EstadoDA estadoDA)
        {
            this.IncidenciaDA = incidenciaDA;
            this.EstadoDA = estadoDA;
        }

        // GET: IncidenciaController
        public ActionResult Index()
        {
            IncidenciaIndexVM model = new();
            model.Estados = new();
            model.Estados.Add(new SelectListItem { Value = "0", Text = "Todos" });
            model.Estado = 0;

            model.Paginas = Combos.ComboNumRegistros();
            model.NumPagina = 10;

            var estados = ObtenerEstados();

            var incidencias = ObtenerIncidencias();
            model.Incidencias = MapearIncidenciasToVM(incidencias);

            return View(model);
        }

        // GET: IncidenciaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IncidenciaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IncidenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IncidenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IncidenciaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<Incidencia> ObtenerIncidencias(){
            return IncidenciaDA.ObtenerIncidencias();
        }

        private Task<List<Estado>> ObtenerEstados()
        {
            return EstadoDA.GetAllAsync();
        }

        private List<IncidenciaGridVM>? MapearIncidenciasToVM(List<Incidencia> incidencias)
        {
            if (!incidencias.Any())
                return null;

            List<IncidenciaGridVM> model = new List<IncidenciaGridVM>();

            incidencias.ForEach(i =>
            {
                IncidenciaGridVM incidencia = new();
                incidencia.Identificador = i.Id;
                incidencia.TipoIncidencia = i.TipoIncidencia?.Nombre;
                incidencia.Poblacion = i.Poblacion;
                incidencia.Direccion = i.Direccion;
                incidencia.FechaIncidencia = i.Fecha;
                incidencia.Estado = i.Estado?.Descripcion;

                model.Add(incidencia);
            });

            return model;
        }

        //private List<SelectListItem> ObtenerComboEstados()
        //{
        //    List<SelectListItem> combo = new();
        //    var estados = EstadoDA.GetAllAsync();

        //    foreach(Estado estado in estados)
        //    {

        //    }
        //}
    }
}
