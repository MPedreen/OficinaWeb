using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Data;
using OficinaWeb.Models;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class CarrosController : Controller
    {
        private readonly OficinaWebContext _db;

        public CarrosController(OficinaWebContext db)
        {
            _db = db;
        }
        public IActionResult List()
        {
            IEnumerable<Carro> objList = _db.Carros;
            return View(objList);
        }

        // GET-Create
        public IActionResult Create()
        {
            return View();
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Carro obj)
        {
            if(ModelState.IsValid)
            {
                _db.Carros.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(obj);
         
        }
    }
}