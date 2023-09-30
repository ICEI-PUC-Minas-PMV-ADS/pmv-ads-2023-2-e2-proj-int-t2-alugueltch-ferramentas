using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Ferramenta = new HashSet<Ferramentum>();
            Processos = new HashSet<Processo>();
        }

        public long Id { get; set; }
        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public char Sexo { get; set; }
        public DateOnly DataNascimento { get; set; }
        public string Email { get; set; } = null!;
        public string Telefone { get; set; } = null!;
        public long EnderecoId { get; set; }
        public string Funcional { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;
        public short PermissaoId { get; set; }
        public short PapelId { get; set; }
        public DateOnly DataAdmissao { get; set; }
        public DateOnly? DataDemissao { get; set; }

        public virtual Endereco Endereco { get; set; } = null!;
        public virtual TipoPapel Papel { get; set; } = null!;
        public virtual TipoPermissao Permissao { get; set; } = null!;
        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }
}
