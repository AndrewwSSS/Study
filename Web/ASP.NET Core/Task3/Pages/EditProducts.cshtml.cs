using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;
namespace Task3.Pages
{
    [IgnoreAntiforgeryToken]
    public class EditProductsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; }
        public Rozetka2Context Context { get; set; }

        public EditProductsModel(Rozetka2Context context)  {
            Context = context;
        }

        public IActionResult OnPost(Product product)
        {
            var productToUpdate = Context.Products.FirstOrDefault(p => p.Id == product.Id);

            if(productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.Manufacturer = product.Manufacturer;
                productToUpdate.Price = product.Price;
                productToUpdate.ImgUrl = product.ImgUrl;
                productToUpdate.Type = product.Type;

                Context.SaveChanges();
            }

            return Redirect("/EditProducts/");


        }
    }
}
