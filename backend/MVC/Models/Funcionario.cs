using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        public string Cpf { get; set; } = null!;

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "O campo Sexo é obrigatório.")]
        public char Sexo { get; set; }

        [Required(ErrorMessage = "O campo data de nascimento é obrigatório.")]
        public DateOnly DataNascimento { get; set; }
        public string DataNascimentoFormatada()
        {
            return this.DataNascimento.ToString("dd/MM/yyyy");
        }





        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; } = null!;

        [Required(ErrorMessage = "O campo Funcional é obrigatório.")]

        public string Funcional { get; set; } = null!;

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]

        [DataType(DataType.Password)]
        public string Senha { get; set; } = null!;

        [Required(ErrorMessage = "O campo Permissão é obrigatório.")]

        public short PermissaoId { get; set; }

        

        [Required(ErrorMessage = "O campo Papel é obrigatório.")]
        public short PapelId { get; set; }

      


        public long  EnderecoId { get; set; }

        [Required(ErrorMessage = "O campo data de adimissão é obrigatório.")]


        [Display(Name = "Data de Admissão")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly DataAdmissao { get; set; }
        public string DataAdmissaoFormatada()
        {
            return this.DataAdmissao.ToString("dd/MM/yyyy");
        }
        public DateOnly? DataDemissao { get; set; }


        

        [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
        public virtual Endereco Endereco { get; set; }

        

        public virtual TipoPapel? Papel { get; set; }

        
        public virtual TipoPermissao? Permissao { get; set; }

      
        public virtual ICollection<Ferramentum> Ferramenta { get; set; }
        public virtual ICollection<Processo> Processos { get; set; }
    }
}
