using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace AutoNomā.Pages.Cars
{
    public class ListModel : PageModel
    {
        public List<Auto> Cars { get; set; } = new List<Auto>();

        public void OnGet()
        {
            
            Cars = new List<Auto>
            {
                new Auto { Marka = "Toyota", Modelis = "Corolla", Gads = 2020, CenaParStundu = 15 },
                new Auto { Marka = "BMW", Modelis = "320i", Gads = 2021, CenaParStundu = 25 }
            };
        }
    }
}
