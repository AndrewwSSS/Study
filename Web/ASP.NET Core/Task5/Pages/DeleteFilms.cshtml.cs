using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task5.Pages.Entities;

namespace Task5.Pages
{
    [IgnoreAntiforgeryToken]
    public class DeleteFilmsModel : PageModel
    {
        public FilmsContext Context { get; set; }

        public DeleteFilmsModel(FilmsContext context) {
            Context = context;
        }

        public void OnPost(int id)
        {
            var filmToDelete = Context.Films.FirstOrDefault(f => f.Id == id);

            if(filmToDelete != null) {
                Context.Films.Remove(filmToDelete);
                Context.SaveChanges();
            }
        }

    }
}
