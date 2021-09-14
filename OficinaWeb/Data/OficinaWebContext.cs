using Microsoft.EntityFrameworkCore;
using OficinaWeb.Models;

namespace OficinaWeb.Data
{
    public class OficinaWebContext : DbContext
    {
        public OficinaWebContext(DbContextOptions<OficinaWebContext> options) : base(options)
        {

        }

        public DbSet<Carro> Carros { get; set; }
    }
}