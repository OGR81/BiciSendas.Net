using BiciSendas.BL;
using BiciSendas.DA;
using BiciSendas.DA.Entities;
using BiciSendas.Models;
using BiciSendas.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BiciSendas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IncidenciaBL IncidenciaBL;
        private readonly EstadoBL EstadoBL;
        private List<Incidencia> incidencias = new();
        private List<Estado> estados = new();

        public HomeController(ILogger<HomeController> logger, IncidenciaBL incidenciaBL, EstadoBL estadoBL)
        {
            _logger = logger;
            IncidenciaBL = incidenciaBL;
            EstadoBL = estadoBL;
        }

        public IActionResult Index()
        {
            ObtenerInfoIncidencias();   
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void ObtenerInfoIncidencias()
        {
            incidencias =  IncidenciaBL.ObtenerIncidencias().Result;
            estados = EstadoBL.ObtenerEstados().Result;
            ViewBag.TotalIncidencias = IncidenciaBL.ObtenerTotalIncidencias(incidencias);
            ViewBag.IncidenciasResueltas = IncidenciaBL.ObtenerTotalResueltas(incidencias, (int)Enums.Estados.Solucionado);
            ViewBag.IncidenciasPendientes = IncidenciaBL.ObtenerTotalPendientes(incidencias, (int)Enums.Estados.Pendiente);
            ViewBag.TotalCaidas = IncidenciaBL.ObtenerTotalCaidas(incidencias, (int)Enums.TipoIncidencia.Caida);
        }

        private void ObtenerInfoRecorrido()
        {

        }


    }
}