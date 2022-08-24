using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task2.Pages
{
    public class Task4Model : PageModel
    {

        public string[] Restaurants = new string[] { "Osteria Francescana", "Eleven Madison Park", "Mirazur", "Noma", "El Celler de Can Roca" };

        public void OnGet()
        {
        }
    }
}
