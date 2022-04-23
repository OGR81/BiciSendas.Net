using BiciSendas.Areas.Monitorizacion.Models.Incidencias;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiciSendas.Areas.Monitorizacion.Controllers
{
    [Area("Monitorizacion")]
    public class IncidenciaController : Controller
    {
        // GET: IncidenciaController
        public ActionResult Index()
        {
            IncidenciaIndexVM model = new();
            model.Estados = new();
            model.Estados.Add(new SelectListItem { Value = "0", Text = "Todos" });
            model.Estado = 0;

            model.Paginas = new();
            model.Paginas.Add(new SelectListItem { Value = "10", Text = "10" });
            model.Paginas.Add(new SelectListItem { Value = "20", Text = "20" });
            model.Paginas.Add(new SelectListItem { Value = "30", Text = "30" });
            model.NumPagina = 10;

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
    }
}
