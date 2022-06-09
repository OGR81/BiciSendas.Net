using BiciSendas.Areas.Operaciones.Models.ElementosVias;
using BiciSendas.BL;
using BiciSendas.DA.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BiciSendas.Areas.Operaciones.Controllers
{
    [Area("Operaciones")]
    public class ElementoViaController: Controller
    {
        private readonly ElementoViaBL ElementoViaBL;

        public ElementoViaController(ElementoViaBL elementoViaBL)
        {
            ElementoViaBL = elementoViaBL;
        }

        // GET: ElementoViaController
        public IActionResult Index()
        {
            ElementoViaIndexVM model = new();

            return View(model);
        }

        [HttpGet]
        public PartialViewResult CargarElementosVia()
        {
            List<ElementoVia> elementos = ElementoViaBL.ObtenerElementosVia().Result;
            List<ElementoViaGridVM>? items = MapearElementosViaToVM(elementos);

            return PartialView("_GridElementoVia", items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Grabar(ElementoViaIndexVM model)
        {
            if (!ModelState.IsValid) 
                return Json(new { success = false});

            ElementoVia elementoVia = MapearElementoViaVMToEntity(model);

            List<string> errores = ElementoViaBL.Validar(elementoVia);

            if (errores.Any())
            {
                return Json(new { success = false, errors = errores });
            }

            await ElementoViaBL.Grabar(elementoVia);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int idElementoVia)
        {
            try
            {
                await ElementoViaBL.Eliminar(idElementoVia);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        private ElementoVia MapearElementoViaVMToEntity(ElementoViaIndexVM model)
        {
            ElementoVia elementoVia = new();
            elementoVia.Identificador = model.Identificador?.Replace("'", "´").Trim();
            elementoVia.Nombre = model.Nombre?.Replace("'","´").Trim();
            elementoVia.TipoElemento = model.Nombre?.Replace("'", "´").Trim();

            return elementoVia;
        }

        private List<ElementoViaGridVM>? MapearElementosViaToVM(List<ElementoVia> elementos)
        {
            List<ElementoViaGridVM> model = new();

            elementos.ForEach(e =>
            {
                ElementoViaGridVM elemento = new();
                elemento.Id = e.IdElementoVia;
                elemento.Nombre = e.Nombre!.ToUpper();

                model.Add(elemento);
            });

            return model;
        }
    }
}

