using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Models;

namespace MVC.Controllers.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrcamentosAPIController : ControllerBase
    {

        private readonly atdbContext _context;
        public OrcamentosAPIController(atdbContext context)
        {
            _context = context;
        }

        public class OrcamentoRequestModel
        {
            public string ClienteCpf { get; set; }
            public List<FerramentaModel> Ferramenta { get; set; }
            public DateTime DataOrcamento { get; set; }
            public DateTime DataValidade { get; set; }
            public decimal ValorTotal { get; set; }
        }

        public class FerramentaModel
        {
            public string Codigo { get; set; }
            public long Quantidade { get; set; }
        }


        [HttpPost]
        public IActionResult CreateOrcamento([FromBody] OrcamentoRequestModel orcamentoRequest)
        {
            IQueryable<Cliente> ClientQuery = _context.Clientes.AsQueryable();
            IQueryable<Ferramentum> FQuery = _context.Ferramenta.AsQueryable();

            ClientQuery = ClientQuery.Where(cliente => cliente.Cpf
                        .Contains(orcamentoRequest.ClienteCpf));

            Cliente cliente = ClientQuery.FirstOrDefault();
            List<Orcamento_ferramenta> new_ofs = new List<Orcamento_ferramenta>();
            Orcamento new_orcamento = new Orcamento
            {
                ClienteCpf = orcamentoRequest.ClienteCpf,
                DataOrcamento = orcamentoRequest.DataOrcamento,
                DataValidade = orcamentoRequest.DataValidade,
                ValorTotal = orcamentoRequest.ValorTotal,
                ClienteCpfNavigation = cliente,
                
            };




            for (int i = 0; i < orcamentoRequest.Ferramenta.Count; i++)
            {
                FQuery = FQuery.Where(F => F.Codigo
                        .Contains(orcamentoRequest.Ferramenta[i].Codigo));
                Ferramentum ferramenta = FQuery.FirstOrDefault();

                if (ferramenta.Quantidade - orcamentoRequest.Ferramenta[i].Quantidade >= 0)
                {
                    ferramenta.Quantidade -= orcamentoRequest.Ferramenta[i].Quantidade;
                }
                else {
                    return BadRequest("Quantidade insuficiente de ferramentas disponíveis.");
                }

                if (new_orcamento.FerramentaCodigo == null)
                {
                    new_orcamento.FerramentaCodigo += ferramenta.Codigo;
                }


                var new_of = new Orcamento_ferramenta
                {
                    ferramenta_id = ferramenta.Codigo,
                    orcamento_id = 1,
                    Orcamento_Orc = new_orcamento,
                    Ferramenta_Orc = ferramenta
                };
                _context.Entry(ferramenta).State = EntityState.Modified;
                _context.Orcamentos_ferramentas.Add(new_of);
                _context.SaveChanges();


            }
            return Ok(new_orcamento); 
        }

    }


}

