using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Emprestimo
    {
        public long Id { get; set; }
        public string ClienteCpf { get; set; } = null!;
        public string FerramentaCodigo { get; set; } = null!;
        public char IndicadorDevolucao { get; set; }
        public decimal ValorTotal { get; set; }
        public DateOnly DataEmprestimo { get; set; }
        public DateOnly DataRetorno { get; set; }

        public virtual Cliente ClienteCpfNavigation { get; set; } = null!;
        public virtual Ferramentum FerramentaCodigoNavigation { get; set; } = null!;
    }
}
