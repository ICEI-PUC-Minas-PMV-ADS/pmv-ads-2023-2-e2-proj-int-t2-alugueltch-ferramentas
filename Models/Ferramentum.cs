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
        [Display(Name = "Tipo Ferramenta")]
        public long TipoId { get; set; }

        public string Marca { get; set; } = null!;

        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = null!;

        [Display(Name = "Situação")]
        public short SituacaoId { get; set; }


        [Display(Name = "Responsável")]
        public string FuncionarioCadastroFuncional { get; set; } = null!;

        [Display(Name = "Valor diária")]
        public decimal ValorDiaria { get; set; }

        [Display(Name = "Valor compra")]
        public decimal ValorCompra { get; set; }

        [Display(Name = "Responsável")]
        public virtual Funcionario? FuncionarioCadastroFuncionalNavigation { get; set; } = null!;
        [Display(Name = "Responsável")]

       
        public virtual TipoSituacao? Situacao { get; set; } = null!;
        public virtual TipoFerramentum? Tipo { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }
}
