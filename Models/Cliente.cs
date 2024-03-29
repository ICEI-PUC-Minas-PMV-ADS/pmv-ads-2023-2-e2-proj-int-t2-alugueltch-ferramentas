﻿using System;
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

        [Required(ErrorMessage = "O CPF deve conter 11 dígitos")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Nome { get; set; } = null!;

        public string? Sexo { get; set; } = null!;

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Insira a data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        public string Telefone { get; set; } = null!;
        public long EnderecoId { get; set; }

        [Display(Name = "Tipo de Pessoa")]
        public string? tipoPessoa { get; set; }

        [Display(Name = "Endereço")]
        public virtual Endereco? Endereco { get; set; } = null!;
        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
        public virtual ICollection<Orcamento> Orcamentos { get; set; }

        [JsonIgnore]
        [NotMapped]
        public Tpessoa Tpessoa { get; set; }

        [JsonIgnore]
        [NotMapped]
        [Display(Name = "Sexo")]
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
