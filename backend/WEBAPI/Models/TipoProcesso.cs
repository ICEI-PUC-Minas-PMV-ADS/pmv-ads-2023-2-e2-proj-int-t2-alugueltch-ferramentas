using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class TipoProcesso
    {
        public TipoProcesso()
        {
            Processos = new HashSet<Processo>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Processo> Processos { get; set; }
    }
}
