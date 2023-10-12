using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public partial class TipoPermissao
    {
        public TipoPermissao()
        {
            Funcionarios = new HashSet<Funcionario>();
        }

        public short Id { get; set; }
        public string Nome { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
