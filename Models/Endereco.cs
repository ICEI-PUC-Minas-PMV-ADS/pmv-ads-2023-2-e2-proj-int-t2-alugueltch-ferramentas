using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
            Funcionarios = new HashSet<Funcionario>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Insira o logradouro")]
        public string Logradouro { get; set; } = null!;
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "Insira o número")]
        public string Numero { get; set; } = null!;

        [Required(ErrorMessage = "Insira o bairro")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "Insira a cidade")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "Insira o estado")]
        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "Insira o país")]
        public string Pais { get; set; } = null!;

        [Required(ErrorMessage = "Insira o CEP")]
        public string Cep { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Cliente> Clientes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
