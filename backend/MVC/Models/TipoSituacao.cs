using System;
using System.Collections.Generic;

namespace MVC.Models
{
    public partial class TipoSituacao
    {
        public TipoSituacao()
        {
            Ferramenta = new HashSet<Ferramentum>();
        }

        public short Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
    }
}
