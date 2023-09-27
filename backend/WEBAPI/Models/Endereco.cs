using System;
using System.Collections.Generic;

namespace WEBAPI.Models
{
    public partial class Endereco
    {
        public long Id { get; set; }
        public string Logradouro { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Numero { get; set; } = null!;
        public string Bairro { get; set; } = null!;
        public string Cidade { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public string Pais { get; set; } = null!;
        public string Cep { get; set; } = null!;

        public virtual Cliente? Cliente { get; set; }
        public virtual Funcionario? Funcionario { get; set; }
    }
}
