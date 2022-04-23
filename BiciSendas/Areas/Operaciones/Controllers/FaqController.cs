using BiciSendas.Areas.Operaciones.Models.Faqs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiciSendas.Areas.Operaciones.Controllers.Faqs
{
    [Area("Operaciones")]
    public class FaqController : Controller
    {

        // GET: FaqController
        public ActionResult Index()
        {
            FaqIndexVM model = new();
            //model.Categoria = new();
            //model.Categoria.Add(new SelectListItem { Value = "0", Text = "Todos" });
            //model.Categoria = 0;

            model.Paginas = new();
            model.Paginas.Add(new SelectListItem { Value = "10", Text = "10" });
            model.Paginas.Add(new SelectListItem { Value = "20", Text = "20" });
            model.Paginas.Add(new SelectListItem { Value = "30", Text = "30" });
            model.NumPagina = 10;

            return View(model);
        }

        // GET: FaqController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FaqController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FaqController/Create
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

        // GET: FaqController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FaqController/Edit/5
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

        // GET: FaqController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FaqController/Delete/5
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
