using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public partial class Ferramentum
    {
        public Ferramentum()
        {
            Emprestimos = new HashSet<Emprestimo>();
            Orcamentos = new HashSet<Orcamento>();
            Processos = new HashSet<Processo>();
        }

        public long Id { get; set; }
        public string Codigo { get; set; } = null!;
        public long TipoId { get; set; }
        public string Marca { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public short SituacaoId { get; set; }
        public string FuncionarioCadastroFuncional { get; set; } = null!;
        public decimal ValorDiaria { get; set; }
        public decimal ValorCompra { get; set; }
        [Display(Name = "CPF")]
        public virtual Funcionario FuncionarioCadastroFuncionalNavigation { get; set; } = null!;
        public virtual TipoSituacao Situacao { get; set; } = null!;
        public virtual TipoFerramentum Tipo { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }
}
