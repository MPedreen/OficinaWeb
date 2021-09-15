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

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Carros.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Carros.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Carros.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        //GET- Update
        public IActionResult Update(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Carros.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Update
        public IActionResult UpdatePost(Carro obj)
        {
            if(ModelState.IsValid)
            {
                _db.Carros.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(obj);
        }

    }
}