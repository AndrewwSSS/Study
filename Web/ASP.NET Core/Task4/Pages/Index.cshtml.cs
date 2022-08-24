using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task4.Pages.Entities;
namespace Task4.Pages
{
    [IgnoreAntiforgeryToken]
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }

        [BindProperty(Name = "name")]
        public string? SearchString { get; set; }

        public BooksContext Context { get; set; }
        public List<Book> DisplayedBooks { get; set; }


        public IndexModel(BooksContext context) {
            Context = context;
        }

        public void OnGet() {
            DisplayedBooks = Context.Books.Include(x => x.Author).ToList();
        }

        public void OnPost(string name) {
            var lowerName = name.ToLower();

            DisplayedBooks = Context.Books.Include(x => x.Author).
                Where(b => b.Name.ToLower().Contains(lowerName) ||
                           b.Style.ToLower().Contains(lowerName) ||
                           b.PublishingHouse.ToLower().Contains(lowerName) ||
                           b.YearOfPublishing.ToString().Contains(lowerName)).ToList();


        }


    }
}