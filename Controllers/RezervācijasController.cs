using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoNomā.Data;


namespace AutoNomā.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervācijasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RezervācijasController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateRezervāciju([FromBody] Rezervācija rezervācija)
        {
            _context.Rezervācijas.Add(rezervācija);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRezervāciju), new { id = rezervācija.Id }, rezervācija);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Rezervācija>> GetRezervāciju(int id)
        {
            var rezervācija = await _context.Rezervācijas.FindAsync(id);
            if (rezervācija == null)
            {
                return NotFound();
            }
            return rezervācija;
        }
    }
}
