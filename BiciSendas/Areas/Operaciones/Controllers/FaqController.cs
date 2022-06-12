using BiciSendas.Areas.Operaciones.Models.Faqs;
using BiciSendas.BL;
using BiciSendas.DA.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BiciSendas.Areas.Operaciones.Controllers
{
    [Area("Operaciones")]
    public class FaqController : Controller
    {
        private readonly FaqBL FaqBL;

        public FaqController(FaqBL faqBL)
        {
            this.FaqBL = faqBL;
        }

        public IActionResult Index()
        {
            FaqIndexVM model = new();
            
            List<Faq> faqs = FaqBL.ObtenerFaqs().Result;
            
            model.Faqs = MapearFaqsToGrid(faqs);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFaq(int idFaq)
        {
            try
            {
                Faq? faq = await FaqBL.ObtenerPorId(idFaq);
                FaqVM faqVM = MapearFaqToVM(faq);

                return Json(faqVM);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Grabar(FaqVM model, bool actualizarPosicion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false });

                Faq? faq = await MapearFaqVMToEntity(model);

                await FaqBL.Guardar(faq, actualizarPosicion);

                return Json(new {success=true});

            }
            catch(Exception ex)
            {
                return Json(new {success=false, message= ex });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int idFaq)
        {
            try
            {
                await FaqBL.Eliminar(idFaq);

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpGet]
        public IActionResult ComprobarPosicion(int idFaq, int posicion)
        {
            try
            {
                bool existe = FaqBL.ExistePosicion(idFaq, posicion);

                return Json(existe);
            }
            catch(Exception ex)
            {
                return Json(ex);
            }
        }

        private async Task<Faq> MapearFaqVMToEntity(FaqVM model)
        {
            Faq? faq = new();

            if (model.IdFaq != 0)
            {
                faq = await FaqBL.ObtenerPorId((int)model.IdFaq);
                faq!.FechaModificacion = DateTime.Now;
            }
            else
            {
                faq.FechaAlta = DateTime.Now;
            }

            faq.Pregunta = model.Titulo;
            faq.Respuesta = model.Descripcion;
            faq.Posicion = model.Posicion!;

            return faq;
        }

        private static FaqVM MapearFaqToVM(Faq? faq)
        {
            FaqVM faqVM = new();
            faqVM.IdFaq = faq!.IdFaq;
            faqVM.Titulo = faq.Pregunta;
            faqVM.Descripcion = faq.Respuesta;
            faqVM.Posicion = faq.Posicion;

            return faqVM;
        }

        private static List<FaqGridVM>? MapearFaqsToGrid(List<Faq> faqs)
        {
            List<FaqGridVM> model = new();

            faqs.ForEach(i =>
            {
                FaqGridVM faq = new();
                faq.Identificador = i.IdFaq;
                faq.Pregunta = i.Pregunta;
                faq.Respuesta = i.Respuesta;
                faq.FechaAlta = i.FechaAlta;
                faq.FechaModificacion = i.FechaModificacion;
                faq.Posicion = i.Posicion;
                
                model.Add(faq);
            });

            return model;
        }
    }
}
