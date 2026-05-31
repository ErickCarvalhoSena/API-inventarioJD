

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
    }
}