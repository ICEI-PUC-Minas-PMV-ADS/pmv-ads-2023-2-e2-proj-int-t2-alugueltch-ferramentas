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

            ClientQuery = ClientQuery.Where(cliente => cliente.Cpf == orcamentoRequest.ClienteCpf);

            Cliente cliente = ClientQuery.FirstOrDefault();
            if (cliente == null) return BadRequest("Status code 400 - Cliente não encontrado");

            List<Orcamento_ferramenta> new_ofs = new List<Orcamento_ferramenta>();
            Orcamento new_orcamento = new Orcamento
            {
                ClienteCpf = orcamentoRequest.ClienteCpf,
                DataOrcamento = orcamentoRequest.DataOrcamento,
                DataValidade = orcamentoRequest.DataValidade,
                ValorTotal = orcamentoRequest.ValorTotal,
                ClienteCpfNavigation = cliente,
                active = true,
                
            };


            for (int i = 0; i < orcamentoRequest.Ferramenta.Count; i++)
            {

                foreach (FerramentaModel codigo in orcamentoRequest.Ferramenta)
                {
                    if (codigo.Codigo == "") return BadRequest($"Status code 400 - Código da ferramenta não foi preenchido corretamente");

                
                }

                FQuery = FQuery.Where(F => F.Codigo == orcamentoRequest.Ferramenta[i].Codigo);
                Ferramentum ferramenta = FQuery.FirstOrDefault();



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

  


            return Ok($"Status Code 200 - Criado com sucesso! {new_orcamento}"); 
        }



        [HttpGet("relatorios/{dataInicial:DateTime}/{dataFinal:DateTime}")]
        public async Task<ActionResult<List<Orcamento>>> relatorios(DateTime dataInicial, DateTime datafinal)
        {
            var query = _context.Orcamentos.AsQueryable();

                query = query.Where(orc => orc.DataOrcamento >= dataInicial && orc.DataOrcamento <= datafinal)
                             .Include(orc => orc.ClienteCpfNavigation)
                             .Include(orc => orc.Processos_Many)
                                  .ThenInclude(proc_Many => proc_Many.Ferramenta_Orc);

            return Ok(query);
        }

        [HttpGet("relatorios/{id:int}")] 
        public async Task<ActionResult<Orcamento>> relatorios(int id)
        {
            var query = _context.Orcamentos.AsQueryable();

                query = query.Where(orc => orc.Id == id)
                             .Include(orc => orc.ClienteCpfNavigation)
                             .Include(orc => orc.Processos_Many)
                                  .ThenInclude(proc_Many => proc_Many.Ferramenta_Orc);

            return Ok(query);
        }
    }
}

