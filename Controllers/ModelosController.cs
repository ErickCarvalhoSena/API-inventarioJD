

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

    }
}