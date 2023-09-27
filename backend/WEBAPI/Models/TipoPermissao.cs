using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class TipoPermissao
    {
        public TipoPermissao()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public short Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
