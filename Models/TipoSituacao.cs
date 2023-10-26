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

        public string GetDisponibilidade()
        {
            if (Ferramenta != null && Ferramenta.Any(f => f.Quantidade >= 1))
            {
                return "Disponível"; // Se houver pelo menos uma ferramenta com quantidade >= 1, está disponível
            }
            return "Indisponível"; // Se não houver ferramentas com quantidade >= 1, está indisponível
        }


    }
}