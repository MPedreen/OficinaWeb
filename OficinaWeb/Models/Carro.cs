using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OficinaWeb.Models
{
    public class Carro
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Modelo")]
        public string ModeloCarro { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
    }
}