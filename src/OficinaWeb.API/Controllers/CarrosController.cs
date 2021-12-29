using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Domain;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Infra.Repositories.Context;
using OficinaWeb.Models;
using System;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class CarrosController : Controller
    {
        private readonly OficinaWebContext _db;
        private readonly ICarroRepository _carroRepository;
        private readonly IMapper _mapper;

        public CarrosController(ICarroRepository carroRepository, IMapper mapper, OficinaWebContext db)
        {
            _db = db;
            _carroRepository = carroRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            //convertendo domain para view model
            List<CarroViewModel> carroViewModels = new List<CarroViewModel>();

            IEnumerable<Carro> carros = _carroRepository.GetAll();

            carroViewModels = _mapper.Map<List<CarroViewModel>>(carros);

            return View(carroViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarroViewModel carroViewModel = new CarroViewModel();
            carroViewModel.DataCadastro = DateTime.Now;
            return View(carroViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePost(CarroViewModel carroViewModel)
        {
            if (ModelState.IsValid)
            {
                Carro carro = _mapper.Map<Carro>(carroViewModel);
                _carroRepository.Save(carro);
                return RedirectToAction("List");
            }
            return View(carroViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id, CarroViewModel carroViewModel)
        {
            if (id is null)
                return NotFound();

            var carro = _db.Carros.Find(id);

            if (carro is null)
                return NotFound();

            carroViewModel = _mapper.Map<CarroViewModel>(carro);
            return View(carroViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            _carroRepository.Delete(id);
            return RedirectToAction("List");
        }

        public IActionResult Update(int? id, CarroViewModel carroViewModel)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Carros.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            carroViewModel = _mapper.Map<CarroViewModel>(obj);
            return View(carroViewModel);
        }

        public IActionResult UpdatePost(CarroViewModel carroViewModel)
        {
            if (ModelState.IsValid)
            {
                Carro carro = _mapper.Map<Carro>(carroViewModel);
                _carroRepository.Update(carro);
                return RedirectToAction("List");
            }
            return View(carroViewModel);
        }

    }
}