using System.Collections.Generic;
using OficinaWeb.Domain;

namespace OficinaWeb.Infra.Repositories.Abstractions
{
    public interface IProdutoRepository
    {
        void Save(Produto produto);
        void Update(Produto produto);
        void Delete(int? id);
        List<Produto> GetAll();
    }
}