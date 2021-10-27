using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OficinaWeb.Models
{
    public class CarroViewModel
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Modelo")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string ModeloCarro { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [DisplayName("Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
    }
}