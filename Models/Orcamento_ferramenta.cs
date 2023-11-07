using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Orcamento_ferramenta
    {

        public long Id { get; set; }

        public long? orcamento_id { get; set; } = null!;

        public string? ferramenta_id { get; set; } = null!;

        public virtual Ferramentum? Ferramenta_Orc { get; set; } = null!;
        public virtual Orcamento? Orcamento_Orc { get; set; } = null!;

    }
}
