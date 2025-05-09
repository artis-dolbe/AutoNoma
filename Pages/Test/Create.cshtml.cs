using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Test
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public string TestMessage { get; set; }

        public void OnGet()
        {
            Console.WriteLine(">>> OnGet tika izsaukts");
        }

        public IActionResult OnPost()
        {
            Console.WriteLine(">>> OnPost tika izsaukts");
            Console.WriteLine($">>> Saņemts: {TestMessage}");
            return RedirectToPage("/Index");
        }
    }
}
