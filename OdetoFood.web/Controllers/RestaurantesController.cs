using OdetoFood.data.Models;
using OdetoFood.data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdetoFood.web.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly IRestauranteData db;

        public RestaurantesController(IRestauranteData db)
        {
            this.db = db;
        }


        // GET: Restaurantes
        public ActionResult Index()
        {
            var model = db.GetAll(); 
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("notfound");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurante restaurantes)
        {
            
            if (ModelState.IsValid)
            {
                db.add(restaurantes);
                return RedirectToAction("Details", new {id = restaurantes.Id});
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var Model = db.Get(id);
            if(Model == null)
            {
                return HttpNotFound();
            }
            return View(Model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurante restaurante)
        {
            
            if (ModelState.IsValid)
            {
                db.update(restaurante);
                TempData["Message"] = "se ha guardado correctamente el restaurante";
                return RedirectToAction("Details", new { id = restaurante.Id });
            }
            return View(restaurante);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("notfound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            db.delete(id);
            return RedirectToAction("index");
        }
    }
}