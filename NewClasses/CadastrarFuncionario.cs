using MVC.Models;

namespace MVC.NewClasses
{
    public class CadastrarFuncionario
    {

        public Funcionario Funcionario { get; set; }
        public Endereco Endereco { get; set; }



        public short Permissao {  get; set; }
        public short Papel { get; set; }
    }
}
