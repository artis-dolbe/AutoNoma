using AutoNomā.Data; 
using AutoNomā.Models;  
using Microsoft.AspNetCore.Mvc;

namespace AutoNomā.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutomobiļiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AutomobiļiController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> AddAutomobiļi([FromBody] Auto auto)
        {
            _context.Automobiļi.Add(auto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAutomobiļi), new { id = auto.Id }, auto);
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Auto>> GetAutomobiļi(int id)
        {
            var auto = await _context.Automobiļi.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return auto;
        }
    }
}
