using System;

namespace OficinaWeb.Domain
{
    public class Produto
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataCadastro { get; set; }
        public float PrecoCusto { get; set; }
        public float PrecoVenda { get; set; }
        public string Descricao { get; set; }
    }
}