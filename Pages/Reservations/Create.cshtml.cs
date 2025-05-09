using AutoNomā.Models;
using AutoNomā.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AutoNomā.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rezervācija Rezervācija { get; set; } = new Rezervācija();

        public List<Auto> Cars { get; set; } = new();

        public void OnGet()
        {
            if (!_context.Automobiļi.Any())
            {
                _context.Automobiļi.AddRange(
                    new Auto { Marka = "Toyota", Modelis = "Corolla", Gads = 2020, CenaParStundu = 15 },
                    new Auto { Marka = "BMW", Modelis = "320i", Gads = 2021, CenaParStundu = 25 }
                );
                _context.SaveChanges();
            }
            Cars = _context.Automobiļi.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine(">>> OnPostAsync tika izsaukts!");

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"ModelState error: {state.Key}→ {error.ErrorMessage}");
                }
            }
            if (!ModelState.IsValid)
            {
                Cars = _context.Automobiļi.ToList();
                return Page();
            }
             Console.WriteLine($"Dati saņemti: AutoId={Rezervācija.AutoId}, No={Rezervācija.StartDate}, Līdz={Rezervācija.EndDate}");

            _context.Rezervācijas.Add(Rezervācija);
            await _context.SaveChangesAsync();

            Console.WriteLine(">>> Rezervācija saglabāta.");
            
            return RedirectToPage("/Index");
        }
    }
}


