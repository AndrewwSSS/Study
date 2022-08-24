using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task4.Pages.Entities;

namespace Task4.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditBookModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }

        public BooksContext Context { get; set; }



        public EditBookModel(BooksContext context)
        {
            Context = context;
        }


        public IActionResult OnPost(Book book)
        {

            var bookToEdit = Context.Books.Include(x => x.Author).FirstOrDefault(b => b.Id == Id);

            if (bookToEdit != null)
            {
                if (book.YearOfPublishing == 0 ||
                    book.PublishingHouse == null ||
                    book.Name == null ||
                    book.Style == null ||
                    book.ImgUrl == null ||
                    book.Author.Name == null ||
                    book.Author.Surname == null ||
                    book.Author.Patronymic == null)
                    {
                        return RedirectToPage();
                    }

                bookToEdit.Name = book.Name;
                bookToEdit.PublishingHouse = book.PublishingHouse;
                bookToEdit.YearOfPublishing = book.YearOfPublishing;
                bookToEdit.Style = book.Style;
                bookToEdit.ImgUrl = book.ImgUrl;
                bookToEdit.Author.Name = book.Author.Name;
                bookToEdit.Author.Surname = book.Author.Surname;
                bookToEdit.Author.Patronymic = book.Author.Patronymic;

                Context.SaveChanges();

                return Redirect("../Index");
            }






            return RedirectToPage();
           
        }

    }
}
