using AutoNomā.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AutoNomā.Pages.Lietotāji
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public Lietotājs Lietotājs { get; set; } = new Lietotājs();

        
        public void OnGet()
        {
        }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)  
            {
                return Page();  
            }

            
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(Lietotājs),
                Encoding.UTF8,
                "application/json"
            );

            
            var response = await _httpClient.PostAsync("https://localhost:5001/api/Lietotāji/register", jsonContent);

            if (response.IsSuccessStatusCode)  
            {
                
                return RedirectToPage("/Index");
            }

            
            ModelState.AddModelError(string.Empty, "Kļūda reģistrēšanas laikā.");
            return Page();  
        }
    }
}

