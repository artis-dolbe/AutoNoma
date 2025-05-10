using AutoNomā.Data;
using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoNomā.Pages.Reservations
{
    [ValidateAntiForgeryToken]
    public class ListModel : PageModel
    {
        private readonly AppDbContext _context;

        public ListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Rezervācija> Rezervācijas { get; set; } = new();

        public void OnGet()
        {
            Rezervācijas = _context.Rezervācijas
                .Include(r => r.Auto)
                .ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var rezervacija = await _context.Rezervācijas.FindAsync(id);

            if (rezervacija != null)
            {
                _context.Rezervācijas.Remove(rezervacija);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}