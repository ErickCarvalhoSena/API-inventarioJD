

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaJD.API.Data;
using OficinaJD.API.Models;

namespace OficinaJD.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ModelosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ModelosController (AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Modelo>>> ObterModelos()
        {
            return await _context.Modelos.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Modelo>> CadastrarModelo(Modelo modelo)
        {
            _context.Modelos.Add(modelo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterModelos), new {id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarModelo(int id, Modelo modelo)
        {
            if(id != modelo.Id)
            {
                return BadRequest();
            }

            _context.Entry(modelo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarModelos(int id)
        {
            var modelo = await _context.Modelos.FindAsync(id);

            if(modelo == null)
            {
                return NotFound();
            }

            _context.Modelos.Remove(modelo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}