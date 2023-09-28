using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Processo
    {
        public long Id { get; set; }
        public string Funcionario { get; set; } = null!;
        public string CodigoFerramenta { get; set; } = null!;
        public long TipoProcesso { get; set; }
        public DateOnly Data { get; set; }
        public string Parecer { get; set; } = null!;

        public virtual Ferramentum CodigoFerramentaNavigation { get; set; } = null!;
        public virtual Funcionario FuncionarioNavigation { get; set; } = null!;
        public virtual TipoProcesso TipoProcessoNavigation { get; set; } = null!;
    }
}
