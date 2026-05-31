

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaJD.API.Data;
using OficinaJD.API.Models;

namespace OficinaJD.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PecasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PecasController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peca>>> ObterPecas()
        {
            return await _context.Pecas
                    .Include(p => p.PecaModelos)
                    .ThenInclude(pm => pm.Modelo)
                    .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Peca>> CadastrarPeca(Peca peca)
        {
            _context.Pecas.Add(peca);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPecas), new { id = peca.Id }, peca);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Peca>> ObterPecaPorCodigo(string codigo)
        {
            var peca = await _context.Pecas
                             .Include(p => p.PecaModelos)
                             .ThenInclude(pm => pm.Modelo)
                             .FirstOrDefaultAsync(p => p.Codigo == codigo);
                if(peca == null)
                  return NotFound();

          return Ok(peca);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPeca (int id, Peca peca)
        {
            if( id != peca.Id)
             return BadRequest();

             _context.Entry(peca).State = EntityState.Modified;
             await _context.SaveChangesAsync();

             return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPeca (int id)
        {
            var peca = await _context.Pecas.FindAsync(id);

            if(peca == null)
               return NotFound();

               _context.Pecas.Remove(peca);
               await _context.SaveChangesAsync();

               return NoContent();
        }
    }
}