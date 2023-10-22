using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
   
    public partial class TipoFerramentum
    {
        
        public TipoFerramentum()
        {
            Ferramenta = new HashSet<Ferramentum>();
        }

        public long Id { get; set; }

        [Display(Name = "Categoria")]
        public string Nome { get; set; } = null!;

        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
    }
}
