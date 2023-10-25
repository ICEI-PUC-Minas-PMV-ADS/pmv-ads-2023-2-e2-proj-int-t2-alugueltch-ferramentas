using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<Ferramentum> Ferramenta { get; set; }

        public string Quantidade()
        {
            if (Ferramenta != null && Ferramenta.Count >= 1)
            {
                return "Disponível"; //  pelo menos uma ferramenta disponível
            }
            return "Indisponível"; // se não houver ferramentas, indisponível
        }


    }
}