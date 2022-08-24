using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Task3.Entities;
namespace Task3.Pages
{
    [IgnoreAntiforgeryToken]
    public class DeleteProductsModel : PageModel
    {
        public Rozetka2Context Context { get; set; }


        public DeleteProductsModel(Rozetka2Context context) {
            Context = context;
        }
        
        public void OnPost(int Id)
        {
            var productToDelete = Context.Products.FirstOrDefault(p => p.Id == Id);
            if(productToDelete != null) {
                Context.Products.Remove(productToDelete);
                Context.SaveChanges();
            }
            
        }
    }
}
