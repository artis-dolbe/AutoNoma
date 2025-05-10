using AutoNomā.Data;
using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AutoNomā.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _context;

        public CreateModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Auto> Cars { get; set; } = new();

        [BindProperty]
        public Rezervācija Rezervācija { get; set; } = new();

        public void OnGet()
        {
            if (!_context.Automobiļi.Any())
            {
                _context.Automobiļi.RemoveRange(_context.Automobiļi);
                _context.SaveChanges();

                _context.Automobiļi.AddRange(
                         new Auto { Marka = "Toyota", Modelis = "Corolla", Gads = 2020, CenaParStundu = 15 },
                        new Auto { Marka = "BMW", Modelis = "320i", Gads = 2021, CenaParStundu = 25 }
                );
                _context.SaveChanges();
            }

            Cars = _context.Automobiļi.ToList();
        }

        public IActionResult OnPost()
        {
            Console.WriteLine(">>> OnPost tika izsaukts!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine(">>> ModelState NAV derīgs!");
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"ModelState error: {state.Key} → {error.ErrorMessage}");
                    }
                }

                Cars = _context.Automobiļi.ToList();
                return Page();
            }

            Rezervācija.Statuss = "Aktīva";

            Console.WriteLine($">>> Dati: AutoId={Rezervācija.AutoId}, No={Rezervācija.StartDate}, Līdz={Rezervācija.EndDate}");

            _context.Rezervācijas.Add(Rezervācija);
            _context.SaveChanges();

            Console.WriteLine(">>> Rezervācija saglabāta.");

            return RedirectToPage("/Index");
        }
    }
}
