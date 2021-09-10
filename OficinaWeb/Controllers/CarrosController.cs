using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Models;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class CarrosController : Controller
    {
        public IActionResult Index()
        {
            List<Carro> list = new List<Carro>();
            list.Add(new Carro { Id =1, ModeloCarro = "Civic", Marca = "Honda", Placa = "HJB2378"});

            return View(list);
        }
    }
}