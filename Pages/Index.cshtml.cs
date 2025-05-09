using AutoNomā.Data;
using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace AutoNomā.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

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
    }
}

