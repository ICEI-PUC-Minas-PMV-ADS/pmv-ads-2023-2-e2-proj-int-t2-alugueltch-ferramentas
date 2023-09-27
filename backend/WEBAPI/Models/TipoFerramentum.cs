using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class TipoFerramentum
    {
        public TipoFerramentum()
        {
            Ferramenta = new HashSet<Ferramentum>();
        }

        public long Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
    }
}
