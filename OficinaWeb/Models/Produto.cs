using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OficinaWeb.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Nome do Produto")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public string NomeProduto { get; set; }

        [DisplayName("Data de Cadastro")]
        //gera automaticamente com DateTime.Now;
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Preço de Custo")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(0,int.MaxValue, ErrorMessage = "Este campo é obrigatório.")]
        public float PrecoCusto { get; set; }

        [DisplayName("Preço de Venda")]
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "Este campo é obrigatório.")]
        public float PrecoVenda { get; set; }

        /*
        [DisplayName("Lucro")]
        //gerar automaticamente (preçovenda - preçocusto = lucro)
        [Required(ErrorMessage = "Este campo é obrigatório.")]
        public float Lucro { get; set; }
        */

        [DisplayName("Descrição")]
        public string Descricao { get; set; }
    }
}