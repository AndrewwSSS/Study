using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task4.Pages.Entities;

namespace Task4.Pages
{
    [IgnoreAntiforgeryToken]
    public class DeleteBooksModel : PageModel
    {
        public BooksContext Context { get; set; }


        public DeleteBooksModel(BooksContext context) {
            Context = context;
        }

        public void OnPost(int Id)
        {
            var BookToDelete = Context.Books.Include(x => x.Author).FirstOrDefault(b => b.Id == Id);

            if(BookToDelete != null) {
                BookToDelete.Author.Books.Remove(BookToDelete);
                Context.Books.Remove(BookToDelete);
                Context.SaveChanges();
            }



        } 

        
    }
}
