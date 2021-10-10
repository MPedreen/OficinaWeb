using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Models;
using System;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
            => _produtoRepository = produtoRepository;

        public IActionResult List()
        {
            //TODO: converter para view model
            var produtosDomain = _produtoRepository.GetAll();
            return View(produtosDomain);
        }

        // GET - Create
        public IActionResult Create()
        {
            Produto produto = new Produto();
            produto.DataCadastro = DateTime.Now;
            return View(produto);
        }

        //POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto obj)
        {
            //ProdutoViewModel => ProdutoDomain

            _produtoRepository.Save(produtoDomain);
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
        public IActionResult UpdatePost(Produto obj)
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