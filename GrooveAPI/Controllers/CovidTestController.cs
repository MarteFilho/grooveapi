using GrooveAPI.Context;
using GrooveAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GrooveAPI.Controllers
{
    public class CovidTestController : ControllerBase
    {
        private readonly DataContext _context;

        public CovidTestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/covidtest")]
        public async Task<ActionResult<List<CovidTest>>> Get()
        {

            var tests = await _context.Chekin.AsNoTracking().ToListAsync();
            if (tests == null)
            {
                return NotFound(new { erro = "Nenhum teste encontrado!" });
            }

            return Ok(tests);
        }


        //Criação de um teste
        [HttpPost]
        [Route("v1/covidtest")]
        public async Task<ActionResult<dynamic>> Post([FromBody]CovidTest model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                _context.CovidTest.Add(model);
                await _context.SaveChangesAsync();

            }
            catch
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
            }
            return new
            {
                teste = model,
                mesangem = "Teste cadastrado com sucesso!"
            };
        }
    }
}
