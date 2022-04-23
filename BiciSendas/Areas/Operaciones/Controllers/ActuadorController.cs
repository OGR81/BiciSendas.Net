using BiciSendas.Areas.Operaciones.Models.Actuadores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BiciSendas.Areas.Operaciones.Controllers.Actuadores
{
    [Area("Operaciones")]
    public class ActuadorController : Controller
    {

        // GET: ActuadorController
        public ActionResult Index()
        {
            ActuadorIndexVM model = new();
            model.TipoActuador = new();
            model.TipoActuador.Add(new SelectListItem { Value = "0", Text = "Todos" });

            model.Paginas = new();
            model.Paginas.Add(new SelectListItem { Value = "10", Text = "10" });
            model.Paginas.Add(new SelectListItem { Value = "20", Text = "20" });
            model.Paginas.Add(new SelectListItem { Value = "30", Text = "30" });
            model.NumPagina = 10;

            return View(model);
        }

        // GET: ActuadorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActuadorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActuadorController/Create
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

        // GET: ActuadorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActuadorController/Edit/5
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

        // GET: ActuadorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActuadorController/Delete/5
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
