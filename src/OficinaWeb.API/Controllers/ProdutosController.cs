using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Domain;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Models;
using System;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public IActionResult List()
        {
            //convertendo domain para view model
            List<ProdutoViewModel> produtoViewModels = new List<ProdutoViewModel>();

            IEnumerable<Produto> produtos = _produtoRepository.GetAll();

            produtoViewModels = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(produtoViewModels);
        }

        // GET - Create
        public IActionResult Create()
        {
            ProdutoViewModel produto = new ProdutoViewModel();
            produto.DataCadastro = DateTime.Now;
            return View(produto);
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            //ProdutoViewModel => ProdutoDomain
            Produto produto = _mapper.Map<Produto>(produtoViewModel);
            _produtoRepository.Save(produto);
            return RedirectToAction("List");
        }

        //GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Produtos.Find(id);
            if (obj == null)
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
            var obj = _db.Produtos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Produtos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("List");
        }

        //GET - Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Produtos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        //POST - Update
        public IActionResult UpdatePost(ProdutoViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(obj);
        }
    }
}