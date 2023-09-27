using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class TipoPapel
    {
        public TipoPapel()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
