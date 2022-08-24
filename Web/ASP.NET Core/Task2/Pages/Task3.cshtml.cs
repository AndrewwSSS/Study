using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Task2.Pages
{
    public class Task3Model : PageModel
    {

        public string Address { get; set; }
        public string Name { get; set; }
        public int Places { get; set; }


        public Task3Model()
        {
            Address = "Sovetskaya 15";
            Name = "Hi, Bro";
            Places = 100;
        }

        public void OnGet()
        {
        }
    }
}
