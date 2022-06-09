using BiciSendas.Areas.Operaciones.Models.Faqs;
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
    public class FaqController : Controller
    {
        private readonly FaqBL FaqBL;
        private static List<Faq> faqs = new();

        public FaqController(FaqBL faqBL)
        {
            this.FaqBL = faqBL;
        }

        // GET: FaqController
        public ActionResult Index()
        {
            FaqIndexVM model = new();
            
            List<Faq> faqs = FaqBL.ObtenerFaqs().Result;
            
            model.Faqs = MapearFaqsToVM(faqs);

            return View(model);
        }

        [HttpGet]
        public JsonResult ObtenerFaq(int idFaq)
        {
            try
            {
                Faq? faq = FaqBL.ObtenerPorId(idFaq).Result;
                //FaqVM? faqVM = MapearFaqToVM(faq);

                return Json("");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Grabar([FromBody] FaqVM model)
        {
            try
            {
                //if (model is null)
                //    throw new ArgumentException($"{typeof(FaqVM)} no puede ser nulo");

                if (!ModelState.IsValid)
                    return Json(new { success = false });

                Faq? faq = new();

                if (model.IdFaq == 0)
                {
                    faq = await FaqBL.ObtenerPorId((int)model.IdFaq);
                    faq!.FechaModificacion = DateTime.Now;
                }
                else
                {
                    faq.FechaAlta = DateTime.Now;
                }

                faq.Pregunta = model.Pregunta;
                faq.Respuesta = model.Respuesta;
                faq.Posicion = model.Posición;

                await FaqBL.Guardar(faq);

                return Json(new {success=true});

            }
            catch(Exception ex)
            {
                return Json(new { message= ex });
            }
        }

        private List<FaqGridVM>? MapearFaqsToVM(List<Faq> faqs)
        {
            List<FaqGridVM> model = new List<FaqGridVM>();

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
