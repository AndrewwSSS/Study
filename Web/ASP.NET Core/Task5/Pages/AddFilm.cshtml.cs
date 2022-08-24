using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task5.Pages.Entities;

namespace Task5.Pages
{
    [IgnoreAntiforgeryToken]
    public class AddFilmModel : PageModel
    {
        public FilmsContext Context { get; set; }

        public AddFilmModel(FilmsContext context) {
            Context = context;
        }

        public IActionResult OnPost(Film film)
        {
            // Imitation 
            film.Seances.Add(new Seance(DateTime.Now, DateTime.Now.AddHours(2)));
            film.Seances.Add(new Seance(DateTime.Now.AddHours(1), DateTime.Now.AddHours(3)));
            Context.Films.Add(film);
            Context.SaveChanges();

            return Redirect($" ../Films/{film.Id}");
        }


    
    }
}
