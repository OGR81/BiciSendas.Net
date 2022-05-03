using BiciSendas.Areas.Operaciones.Models.ElementosVias;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiciSendas.Areas.Operaciones.Controllers
{
    [Area("Operaciones")]
    public class ElementoViaController: Controller
    {
        // GET: ElementoViaController
        public ActionResult Index()
        {
            ElementoViaIndexVM model = new();
            model.Paginas = new();
            model.Paginas.Add(new SelectListItem { Value = "10", Text = "10" });
            model.Paginas.Add(new SelectListItem { Value = "20", Text = "20" });
            model.Paginas.Add(new SelectListItem { Value = "30", Text = "30" });
            model.NumPagina = 10;

            return View(model);
        }

        // GET: ElementoViaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElementoViaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElementoViaController/Create
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

        // GET: ElementoViaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FaqCoElementoViaControllerntroller/Edit/5
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

        // GET: ElementoViaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ElementoViaController/Delete/5
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

