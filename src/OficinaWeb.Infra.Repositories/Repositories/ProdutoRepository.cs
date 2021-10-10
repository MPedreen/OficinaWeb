using System.Collections.Generic;
using System.Linq;
using OficinaWeb.Domain;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Infra.Repositories.Context;

namespace OficinaWeb.Infra.Repositories.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly OficinaWebContext _db;

        public ProdutoRepository(OficinaWebContext db)
            => _db = db;

        public void Save(Produto produto)
        {
            _db.Produtos.Add(produto);
            _db.SaveChanges();
        }

        public void Update(Produto produto)
        {
            _db.Produtos.Update(produto);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var produto = _db.Produtos.Find(id);

            if (produto is not null)
            {
                _db.Produtos.Remove(produto);
                _db.SaveChanges();
            }
        }

        public List<Produto> GetAll()
            => _db.Produtos.ToList();
    }
}