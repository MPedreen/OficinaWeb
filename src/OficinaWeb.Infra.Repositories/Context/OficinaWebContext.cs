using Microsoft.EntityFrameworkCore;
using OficinaWeb.Domain;

namespace OficinaWeb.Infra.Repositories.Context
{
    public class OficinaWebContext : DbContext
    {
        public OficinaWebContext(DbContextOptions<OficinaWebContext> options) : base(options)
        {

        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}