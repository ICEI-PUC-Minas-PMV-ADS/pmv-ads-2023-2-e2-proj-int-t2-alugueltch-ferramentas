using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Orcamento
    {
        public long Id { get; set; }
        public string ClienteCpf { get; set; } = null!;
        public string FerramentaCodigo { get; set; } = null!;
        public decimal ValorTotal { get; set; }
        public DateOnly DataOrcamento { get; set; }
        public DateOnly DataValidade { get; set; }

        public virtual Cliente? ClienteCpfNavigation { get; set; } = null!;
        public virtual Ferramentum? FerramentaCodigoNavigation { get; set; } = null!;
    }
}
