using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MVC.Models
{

    public partial class Cliente
    {
        public Cliente()
        {
            Emprestimos = new HashSet<Emprestimo>();
            Orcamentos = new HashSet<Orcamento>();
        }

        public long Id { get; set; }

        public string Cpf { get; set; } = null!;
        public string Nome { get; set; } = null!;
        public char Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Insira a data de nascimento")]
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; } = null!;

        
        public string Telefone { get; set; } = null!;
        public long EnderecoId { get; set; }

        public string? tipoPessoa { get; set; }

        public virtual Endereco? Endereco { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }

        [JsonIgnore]
        [NotMapped]
        public Tpessoa Tpessoa { get; set; }

        [JsonIgnore]
        [NotMapped]
        public Enum_sexo_client Enum_sexo_client { get; set; }


    }

    public enum Tpessoa
    {

        Física,
        Jurídica
    }

      public enum Enum_sexo_client
    {
    
        Masculino,
        Feminino

    }
}
