using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc;
using AutoNomā.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutoNomā.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LietotājiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LietotājiController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterLietotāju([FromBody] Lietotājs lietotājs)
        {
            
            var existingUser = await _context.Lietotāji
                .FirstOrDefaultAsync(u => u.E_pasts == lietotājs.E_pasts);

            if (existingUser != null)
            {
                
                return Conflict("Lietotājs ar šo e-pastu jau eksistē.");
            }

            
            _context.Lietotāji.Add(lietotājs);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLietotāju), new { id = lietotājs.Id }, lietotājs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lietotājs>> GetLietotāju(int id)
        {
            var lietotājs = await _context.Lietotāji.FindAsync(id);

            if (lietotājs == null)
            {
                return NotFound();
            }

            return lietotājs;
        }
    }
}

