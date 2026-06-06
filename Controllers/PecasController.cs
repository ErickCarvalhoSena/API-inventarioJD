

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OficinaJD.API.Data;
using OficinaJD.API.DTOs;
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
        public async Task<ActionResult<IEnumerable<PecaDTO>>> ObterPecas()
        {
            var pecas = await _context.Pecas
                    .Include(p => p.PecaModelos)
                    .ThenInclude(pm => pm.Modelo)
                    .ToListAsync();

                    return Ok(pecas.Select(p => new PecaDTO
                    {
                        Id = p.Id,
                        Codigo = p.Codigo,
                        Descricao = p.Descricao,
                        Quantidade = p.Quantidade,
                        Localizacao = p.Localizacao,
                        Modelos = p.PecaModelos.Select(pm => pm.Modelo!.Nome).ToList()
                    }));
        }

         [HttpGet("{codigo}")]
        public async Task<ActionResult<PecaDTO>> ObterPecaPorCodigo(string codigo)
        {
            var peca = await _context.Pecas
                .Include(p => p.PecaModelos)
                .ThenInclude(pm => pm.Modelo)
                .FirstOrDefaultAsync(p => p.Codigo == codigo);

            if (peca == null)
                return NotFound();

            return Ok(new PecaDTO
            {
                Id = peca.Id,
                Codigo = peca.Codigo,
                Descricao = peca.Descricao,
                Quantidade = peca.Quantidade,
                Localizacao = peca.Localizacao,
                Modelos = peca.PecaModelos.Select(pm => pm.Modelo!.Nome).ToList()
            });
        }

        [HttpGet("modelo/{modeloId}")]
        public async Task<ActionResult<IEnumerable<PecaDTO>>> ObterPecasPorModelo(int modeloId)
        {
            var pecas = await _context.Pecas
                .Include(p => p.PecaModelos)
                .ThenInclude(pm => pm.Modelo)
                .Where(p => p.PecaModelos.Any(pm => pm.ModeloId == modeloId))
                .ToListAsync();

            return Ok(pecas.Select(p => new PecaDTO
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Descricao = p.Descricao,
                Quantidade = p.Quantidade,
                Localizacao = p.Localizacao,
                Modelos = p.PecaModelos.Select(pm => pm.Modelo!.Nome).ToList()
            }));
        }

        [HttpPost]
        public async Task<ActionResult<PecaDTO>> CadastrarPeca(CriarPecaDTO dto)
        {
            var peca = new Peca
            {
                Codigo = dto.Codigo,
                Descricao = dto.Descricao,
                Quantidade = dto.Quantidade,
                Localizacao = dto.Localizacao
            };

            foreach (var modeloId in dto.ModeloIds)
            {
                peca.PecaModelos.Add(new PecaModelo { ModeloId = modeloId });
            }

            _context.Pecas.Add(peca);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPecas), new { id = peca.Id }, new PecaDTO
            {
                Id = peca.Id,
                Codigo = peca.Codigo,
                Descricao = peca.Descricao,
                Quantidade = peca.Quantidade,
                Localizacao = peca.Localizacao,
                Modelos = dto.ModeloIds.Select(id => id.ToString()).ToList()
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarPeca(int id, CriarPecaDTO dto)
        {
            var peca = await _context.Pecas
                .Include(p => p.PecaModelos)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (peca == null)
                return NotFound();

            peca.Codigo = dto.Codigo;
            peca.Descricao = dto.Descricao;
            peca.Quantidade = dto.Quantidade;
            peca.Localizacao = dto.Localizacao;

            peca.PecaModelos.Clear();
            foreach (var modeloId in dto.ModeloIds)
            {
                peca.PecaModelos.Add(new PecaModelo { ModeloId = modeloId });
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarPeca(int id)
        {
            var peca = await _context.Pecas.FindAsync(id);

            if (peca == null)
                return NotFound();

            _context.Pecas.Remove(peca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("buscar")]
        public async Task<ActionResult<IEnumerable<PecaDTO>>> BuscarPecas(
            [FromQuery] string? codigo,
            [FromQuery] int? modeloId)
        {
            var query = _context.Pecas
                        .Include(p => p.PecaModelos)
                        .ThenInclude(pm => pm.Modelo)
                        .AsQueryable();

            if(!string.IsNullOrEmpty(codigo))
              query = query.Where(p => p.Codigo.Contains(codigo));
              
            if(modeloId.HasValue)
            query = query.Where(p => p.PecaModelos.Any(pm => pm.ModeloId == modeloId));

            var pecas = await query.ToListAsync();

            return Ok(pecas.Select(p => new PecaDTO
            {
                Id = p.Id,
                Codigo = p.Codigo,
                Descricao = p.Descricao,
                Quantidade = p.Quantidade,
                Localizacao = p.Localizacao,
                Modelos = p.PecaModelos.Select(pm => pm.Modelo!.Nome).ToList()
            }));
        }
    }
}