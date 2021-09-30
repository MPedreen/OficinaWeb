using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Data;
using OficinaWeb.Models;
using System;
using System.Collections.Generic;

namespace OficinaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly OficinaWebContext _db;

        public ProdutosController (OficinaWebContext db)
        {
            _db = db;
        }

        public IActionResult List()
        {
            IEnumerable<Produto> objList = _db.Produtos;
            return View(objList);
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
            _db.Produtos.Add(obj);
            _db.SaveChanges();
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
            if(ModelState.IsValid)
            {
                _db.Produtos.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(obj);
        }

        public IActionResult AutomaticDate()
        {
            Produto produto = new Produto();
            produto.DataCadastro = DateTime.Now;

            return View(produto);
        }
    }
}