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
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;
        private readonly OficinaWebContext _db;

        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper, OficinaWebContext db)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public IActionResult List()
        {
            List<ProdutoViewModel> produtoViewModels = new List<ProdutoViewModel>();

            IEnumerable<Produto> produtos = _produtoRepository.GetAll();

            produtoViewModels = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(produtoViewModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ProdutoViewModel produto = new ProdutoViewModel();
            produto.DataCadastro = DateTime.Now;
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                Produto produto = _mapper.Map<Produto>(produtoViewModel);
                _produtoRepository.Save(produto);
                return RedirectToAction("List");
            }
            return View(produtoViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id, ProdutoViewModel produtoViewModel)
        {
            if (id is null || id == 0)
                return NotFound();

            var produtos = _db.Produtos.Find(id);

            if (produtos is null)
                return NotFound();

            produtoViewModel = _mapper.Map<ProdutoViewModel>(produtos);
            return View(produtoViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int? id)
        {
            _produtoRepository.Delete(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Update(int? id, ProdutoViewModel produtoViewModel)
        {
            if (id is null || id == 0)
                return NotFound();

            var produto = _db.Produtos.Find(id);

            if (produto is null)
                return NotFound();

            produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        [HttpPost]
        public IActionResult Update(ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                Produto produto = _mapper.Map<Produto>(produtoViewModel);
                _produtoRepository.Update(produto);
                return RedirectToAction("List");
            }
            return View(produtoViewModel);
        }
    }
}