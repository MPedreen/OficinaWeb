using System;
using System.Collections.Generic;
using System.Linq;
using OficinaWeb.Domain;
using OficinaWeb.Infra.Repositories.Abstractions;
using OficinaWeb.Infra.Repositories.Context;

namespace OficinaWeb.Infra.Repositories.Repositories
{
    public class CarroRepository : ICarroRepository
    {
        private readonly OficinaWebContext _db;

        public CarroRepository(OficinaWebContext db)
            => _db = db;

        public void Save(Carro carro)
        {
            _db.Carros.Add(carro);
            _db.SaveChanges();
        }

        public void Update(Carro carro)
        {
            _db.Carros.Update(carro);
            _db.SaveChanges();
        }

        public void Delete(int? id)
        {
            var carro = _db.Carros.Find(id);

            if (carro is not null)
            {
                _db.Carros.Remove(carro);
                _db.SaveChanges();
            }
        }

        public void GetDelete(int? id)
        {
            if (id is null)
            {
                throw new ArgumentException("Não foi possível encontrar o item.");
            }
            var carro = _db.Carros.Find(id);
            if (carro is null)
            {
                throw new ArgumentException("Não foi possível encontrar o item.");
            }
        }

        public List<Carro> GetAll()
            => _db.Carros.ToList();
    }
}