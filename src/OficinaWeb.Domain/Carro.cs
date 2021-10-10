using System;

namespace OficinaWeb.Domain
{
    public class Carro
    {
        public int Id { get; set; }
        public string ModeloCarro { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}