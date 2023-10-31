using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            public float ValorTotal { get; set; }
        }

        public class FerramentaModel
        {
            public string Codigo { get; set; }
            public float Quantidade { get; set; }
        }


        [HttpPost]
        public IActionResult CreateOrcamento([FromBody] OrcamentoRequestModel orcamentoRequest)
        {
            
            return Ok(orcamentoRequest); 
        }

    }


}

