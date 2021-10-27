using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Domain;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Models;
using System;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IMapper _mapper;

        public CarrosController(ICarroRepository carroRepository, IMapper mapper)
        {
            _carroRepository = carroRepository;
            _mapper = mapper;
        }
        public IActionResult List()
        {
            //convertendo domain para view model
            List<CarroViewModel> carroViewModels = new List<CarroViewModel>();

            IEnumerable<Carro> carros = _carroRepository.GetAll();

            carroViewModels = _mapper.Map<List<CarroViewModel>>(carros);

            return View(carroViewModels);
        }

        // GET-Create
        public IActionResult Create()
        {
            CarroViewModel carro = new CarroViewModel();
            carro.DataCadastro = DateTime.Now;
            return View(carro);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarroViewModel carroViewModel)
        {
            if (ModelState.IsValid)
            {
                Carro carro = _mapper.Map<Carro>(carroViewModel);
                _carroRepository.Save(carro);
                return RedirectToAction("List");
            }
            return View(carroViewModel);
        }

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            CarroViewModel carroViewModel = new CarroViewModel();
            Carro carro = _carroRepository.GetDelete(id); // o erro é nessa linha
            carroViewModel = _mapper.Map<CarroViewModel>(carro);
            return View(carroViewModel);
        }

        //POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            _carroRepository.Delete(id);
            return RedirectToAction("List");
        }

        //GET- Update
        public IActionResult Update(int? id)
        {
            // if (id == null || id == 0)
            // {
            //     return NotFound();
            // }
            // var obj = _carroRepository.
            // if (obj == null)
            // {
            //     return NotFound();
            // }
            return View();
        }

        //POST - Update
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