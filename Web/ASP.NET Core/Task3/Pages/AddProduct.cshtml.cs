using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;
namespace Task3.Pages
{
    [IgnoreAntiforgeryToken]
    public class AddProductModel : PageModel
    {
        public Rozetka2Context Context { get; set; }


        public AddProductModel(Rozetka2Context context){
            Context = context;
        }

        public void OnGet()
        {
        }

        public void OnPost(Product product)
        {
            Context.Products.Add(product);
            Context.SaveChanges();
        }

    }
}
