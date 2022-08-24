using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task5.Pages.Entities;

namespace Task5.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditFilmsModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }

        public FilmsContext Context { get; set; }
         
        public EditFilmsModel(FilmsContext context) { 
            Context = context;
        }

        public IActionResult OnPost(Film film)
        {
            var filmToUpdate = Context.Films.FirstOrDefault(f => f.Id == film.Id);

            if(filmToUpdate != null)
            {
                filmToUpdate.Name = film.Name;
                filmToUpdate.ImageUrl = film.ImageUrl;
                filmToUpdate.Producer = film.Producer;
                filmToUpdate.Style = film.Style;
                filmToUpdate.Description = film.Description;

                Context.SaveChanges();
            }
            return Redirect("../Films/");
        }
             
    }
}
