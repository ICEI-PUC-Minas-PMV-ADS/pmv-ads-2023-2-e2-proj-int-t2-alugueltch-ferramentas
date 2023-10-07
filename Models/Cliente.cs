using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{

    public partial class Cliente
    {
        public Cliente()
        {
            Emprestimos = new HashSet<Emprestimo>();
            Orcamentos = new HashSet<Orcamento>();
        }

        public long Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public char Sexo { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public long EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
    }
}
