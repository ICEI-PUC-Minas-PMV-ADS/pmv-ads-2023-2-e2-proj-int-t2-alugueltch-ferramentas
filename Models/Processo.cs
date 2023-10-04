using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class Processo
    {
        public long Id { get; set; }
        public string FuncionarioResponsavelFuncional { get; set; } = null!;
        public string FerramentaCodigo { get; set; } = null!;
        public short TipoProcessoId { get; set; }
        public DateOnly Data { get; set; }
        public string Parecer { get; set; } = null!;

        public virtual Ferramentum FerramentaCodigoNavigation { get; set; } = null!;
        public virtual Funcionario FuncionarioResponsavelFuncionalNavigation { get; set; } = null!;
        public virtual TipoProcesso TipoProcesso { get; set; } = null!;
    }
}
