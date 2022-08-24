using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;

namespace Task3.Pages
{
    public class AboutModel : PageModel
    {
        public Rozetka2Context Context { get; set; }

        public AboutModel(Rozetka2Context context) {
            Context = context;
        }

    }
}
