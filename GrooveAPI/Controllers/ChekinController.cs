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
    public class ChekinController : ControllerBase
    {
        private readonly DataContext _context;

        public ChekinController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("v1/chekin")]
        public async Task<ActionResult<List<Chekin>>> Get()
        {

            var chekins = await _context.Chekin.AsNoTracking().ToListAsync();
            if (chekins == null)
            {
                return NotFound(new { erro = "Nenhum chekin encontrado!" });
            }

            return Ok(chekins);
        }


        //Criação de um chekin
        [HttpPost]
        [Route("v1/chekin")]
        public async Task<ActionResult<dynamic>> Post([FromBody]Chekin model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new { Erro = "Por favor verifique os dados digitados!" });
            }

            try
            {
                _context.Chekin.Add(model);
                await _context.SaveChangesAsync();

            }
            catch
            {
                return BadRequest(new { Erro = "Não foi possível se conectar com o banco de dados!" });
            }
            return new
            {
                chekin = model,
                mesangem = "Chekin cadastrado com sucesso!"
            };
        }
    }
}
