using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Ferramenta = new HashSet<Ferramentum>();
            Processos = new HashSet<Processo>();
        }

        public long Id { get; set; }

        [Required(ErrorMessage = "Insira o cpf")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O cpf deve conter 11 dígitos.")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "Insira o nome")]
        public string Nome { get; set; } = null!;

        public string? Sexo { get; set; } = null!;


        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Insira a data de nascimento")]
       
        public DateTime DataNascimento { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Insira o e-mail")]
        public string Email { get; set; } = null!;


   
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O telefone deve conter 11 dígitos.")]
        [Required(ErrorMessage = "Insira o telefone")]
        public string Telefone { get; set; } = null!;

        [StringLength(7, MinimumLength = 7, ErrorMessage = "A matrícula deve conter o seguinte formato: FUNC+NNN.")]
        [Required(ErrorMessage = "Insira a matrícula")]

        [Display(Name = "Login")]
        public string Funcional { get; set; } = null!;

        [StringLength(12, MinimumLength = 6, ErrorMessage = "O campo senha deve conter no mínimo 6 caracteres.")]

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Insira o senha")]
        public string Senha { get; set; } = null!;

    

        public short PermissaoId { get; set; }

        public short PapelId { get; set; }

        public long  EnderecoId { get; set; }




        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "O campo data de adimissão é obrigatório.")]
        public DateTime DataAdmissao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataDemissao { get; set; }


 
        public virtual Endereco Endereco { get; set; }

        

        public virtual TipoPapel? Papel { get; set; }

        
        public virtual TipoPermissao? Permissao { get; set; }

      
        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }


        [NotMapped]
        public Enum_sexo Enum_sexo { get; set; }

    }

    public enum Enum_sexo { 

         Masculino,
         Feminino
    
    }


}
