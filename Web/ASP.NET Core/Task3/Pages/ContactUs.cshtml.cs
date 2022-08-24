using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;

namespace Task3.Pages
{
    [IgnoreAntiforgeryToken]
    public class ContactUsModel : PageModel
    {
        public void OnGet()
        {
        }

        public void OnPost(UserRequest request)
        {
            Console.WriteLine(request);
        }

    }
}
