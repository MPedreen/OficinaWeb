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

        public IActionResult Create()
        {
            return View();
        }

    }
}