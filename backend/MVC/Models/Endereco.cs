using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "O campo Logradouro é obrigatório.")]
        public string Logradouro { get; set; } = null!;
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public string Numero { get; set; } = null!;

        [Required(ErrorMessage = "O campo bairro é obrigatório.")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "O campo cidade é obrigatório.")]
        public string Cidade { get; set; } = null!;

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string Estado { get; set; } = null!;

        [Required(ErrorMessage = "O campo País é obrigatório.")]
        public string Pais { get; set; } = null!;

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        public string Cep { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
