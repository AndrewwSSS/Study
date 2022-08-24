using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Task5.Pages.Entities;
namespace Task5.Pages
{
    [IgnoreAntiforgeryToken]
    public class FilmsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? FilmId { get; set; }
        public string? SearchString { get; set; }
        public FilmsContext Context { get; set; }
        public List<Film> DisplaydFilms { get; set; }


        public FilmsModel(FilmsContext context) {
           Context = context;
        }

        public void OnGet()
        {
            DisplaydFilms = Context.Films.ToList();
        }

        public void OnPost(string Name)
        {
            DisplaydFilms = Context.Films.Where(f => f.Name.ToLower().Contains(Name.ToLower()) ||
                                                f.Producer.ToLower().Contains(Name.ToLower()) ||
                                                f.Style.ToLower().Contains(Name.ToLower()) ||
                                                f.Description.ToLower().Contains(Name.ToLower())).ToList();
            SearchString = Name;


        }
    }
}
