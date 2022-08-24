using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task4.Pages.Entities;
namespace Task4.Pages
{
    [IgnoreAntiforgeryToken]
    public class AddBookModel : PageModel
    {

        public BooksContext Context { get; set; }

        public AddBookModel(BooksContext context) {
            Context = context;
        }

        public IActionResult OnPost(Book book)
        {
            if(book.YearOfPublishing == 0 ||
               book.PublishingHouse == null ||
               book.Name == null ||
               book.Style == null ||
               book.ImgUrl == null ||
               book.Author.Name == null ||
               book.Author.Surname == null ||
               book.Author.Patronymic == null) {
                return RedirectToPage();
            }
               
            
            Context.Books.Add(book);
            Context.SaveChanges();
            return Redirect("../Index");
        }
         

    }
}
