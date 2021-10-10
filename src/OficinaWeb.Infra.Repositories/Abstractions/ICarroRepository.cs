using System.Collections.Generic;
using OficinaWeb.Domain;

namespace OficinaWeb.Infra.Repositories.Abstractions
{
    public interface ICarroRepository
    {
        void Save(Carro carro);
        void Update(Carro carro);
        void Delete(int id);
        List<Carro> GetAll();
    }
}