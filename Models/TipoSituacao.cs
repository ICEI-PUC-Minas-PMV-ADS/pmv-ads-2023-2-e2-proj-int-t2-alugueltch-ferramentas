using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public partial class TipoSituacao
    {
        public TipoSituacao()
        {
            Ferramenta = new HashSet<Ferramentum>();
        }

        public short Id { get; set; }

        [Display(Name = "Situação")]
        public string Nome { get; set; } = null!;

        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
    }
}
