using System;
using System.Collections.Generic;

namespace WEBAPI.Models
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
        public long SituacaoId { get; set; }
        public string CadastradoPor { get; set; } = null!;
        public decimal ValorDiaria { get; set; }
        public decimal ValorCompra { get; set; }

        public virtual TipoSituacao Situacao { get; set; } = null!;
        public virtual TipoFerramentum Tipo { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }
}
