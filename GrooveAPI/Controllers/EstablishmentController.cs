using GrooveAPI.Context;
using GrooveAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrooveAPI.Controllers
{
    [Route("v1/establishment")]
    public class EstablishmentController : ControllerBase
    {
        private readonly DataContext _context;

        public EstablishmentController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/establishment")]
        public async Task<ActionResult<List<Establishment>>> Get()
        {

            var Establishment = await _context.Establishment.AsNoTracking().ToListAsync();
            if (Establishment == null)
            {
                return NotFound(new { erro = "Nenhum estabelecimento encontrado!" });
            }

            return Ok(Establishment);

        }


        //Criação do estabelecimento
        [HttpPost]
        [Route("v1/estabelecimento")]
        public async Task<ActionResult<dynamic>> Post([FromBody]Establishment model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                _context.Establishment.Add(model);
                await _context.SaveChangesAsync();

            }
            catch
            {

                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
            }
            return new
            {
                Establishment = model,
                mesangem = "Estabelecimento cadastrado com sucesso!"
            };
        }

    }
}
