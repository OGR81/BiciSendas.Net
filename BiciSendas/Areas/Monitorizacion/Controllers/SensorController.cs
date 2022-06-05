﻿using BiciSendas.Areas.Monitorizacion.Models.Sensores;
using BiciSendas.DA.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BiciSendas.Areas.Monitorizacion.Controllers
{
    [Area("Monitorizacion")]
    public class SensorController : Controller
    {
        // GET: SensorController
        public ActionResult Index()
        {
            SensorIndexVM model = new();
            model.Categorias = new();
            model.Categorias.Add(new SelectListItem { Value = "0", Text = "" });
            model.Categorias.Add(new SelectListItem { Value = "1", Text = "Identificador" });
            model.Categorias.Add(new SelectListItem { Value = "2", Text = "Tipo" });
            model.Categorias.Add(new SelectListItem { Value = "3", Text = "Población" });
            model.Categorias.Add(new SelectListItem { Value = "4", Text = "Dirección" });
            model.Categorias.Add(new SelectListItem { Value = "5", Text = "Fecha de modificación"});

            model.Sensores = MapListEntityToListGridVM(FakeData());

            return View(model);
        }

        // GET: SensorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SensorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SensorController/Create
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

        // GET: SensorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SensorController/Edit/5
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

        // GET: SensorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SensorController/Delete/5
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

        private List<SensorGridVM> MapListEntityToListGridVM(List<Sensor> sensores)
        {
            List<SensorGridVM> list = new();

            if (!sensores.Any())
                return list;

            sensores.ForEach(s => {
                SensorGridVM sensorGridVM = new()
                {
                    Id = s.Id,
                    Identificador = s.Identificador,
                    Nombre = s.Nombre,
                    Estado = Enum.GetName(typeof(Estado), s.Estado!),
                    Categoria = Enum.GetName(typeof(Categoria), s.Categoria!),
                    Coordenadas = s.Coordenadas,
                    FechaModificacion = s.FechaModificacion
                };

                list.Add(sensorGridVM);
            });

            return list;
        }

        [HttpGet]
        public PartialViewResult CargarSensores(int idCategoria)
        {
            //TODO: Cambiar PartialViewResult por async Task<PartialViewResult>
            //      Obtener los sensores desde la api y pasarlos a la grid
            List<SensorGridVM>? items = new();
            return PartialView("_GridSensores", items);
        }

        #region FAKE DATA
        public enum Estado {
            ACTIVO = 1
        }

        public enum Categoria { 
            Cat1 = 1
        }

        public List<Sensor> FakeData()
        {
            List<Sensor> sensores = new();

            Sensor sensor = new() { 
                Identificador = "LT594R",
                Nombre = "Sen.Semáforo",
                Estado = 1,
                Categoria = 1,
                Coordenadas = "40.712728, -74.006015",
                FechaModificacion = new DateTime()
            };

            Sensor sensor1 = new()
            {
                Identificador = "LT594R",
                Nombre = "Sen.Semáforo",
                Estado = 1,
                Categoria = 1,
                Coordenadas = "40.712728, -74.006015",
                FechaModificacion = new DateTime()
            };

            Sensor sensor2 = new()
            {
                Identificador = "LT594R",
                Nombre = "Sen.Semáforo",
                Estado = 1,
                Categoria = 1,
                Coordenadas = "40.712728, -74.006015",
                FechaModificacion = new DateTime()
            };

            Sensor sensor3 = new()
            {
                Identificador = "LT594R",
                Nombre = "Sen.Semáforo",
                Estado = 1,
                Categoria = 1,
                Coordenadas = "40.712728, -74.006015",
                FechaModificacion = new DateTime()
            };

            Sensor sensor4 = new()
            {
                Identificador = "LT594R",
                Nombre = "Sen.Semáforo",
                Estado = 1,
                Categoria = 1,
                Coordenadas = "40.712728, -74.006015",
                FechaModificacion = new DateTime()
            };

            sensores.Add(sensor);
            sensores.Add(sensor2);
            sensores.Add(sensor3);
            sensores.Add(sensor4);

            return sensores;
        }
        #endregion
    }
}
