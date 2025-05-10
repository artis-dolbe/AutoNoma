using AutoNomā.Data;
using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AutoNomā.Pages.Cars
{
    public class ListModel : PageModel
    {
        private readonly AppDbContext _context;

        public ListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Auto> Cars { get; set; } = new();

        public void OnGet()
        {
            Cars = _context.Automobiļi
                .ToList();
        }
    }
}
