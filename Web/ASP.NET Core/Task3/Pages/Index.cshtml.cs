using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;
using Task3.Entities;

namespace Task3.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true, Name = "id")]
        public int CurrentId { get; set; }

        public Rozetka2Context Context { get; set; }
        public List<Product>? DisplaedProducts;
        public SearchParameters? CurrParams { get; set; }

        public IndexModel(Rozetka2Context context) {
            Context = context;
            DisplaedProducts = Context.Products.ToList();
        }



        public void OnPostSubmit(SearchParameters parameters)
        {
            if (parameters.SumFrom == null)
                parameters.SumFrom = 0;
            if (parameters.SumTo == null)
            {
                if(parameters.ProductType == null)
                {
                    DisplaedProducts = Context.Products.Where(
                        p => p.Price >= parameters.SumFrom).ToList();
                }
                else
                {

                    DisplaedProducts = Context.Products.Where(
                       p => p.Price >= parameters.SumFrom &&
                       p.Type == parameters.ProductType).ToList();
                }

            }
            else
            {
                if (parameters.ProductType == null)
                {
                    DisplaedProducts = Context.Products.Where(
                        p => p.Price >= parameters.SumFrom
                        && p.Price <= parameters.SumTo).ToList();
                }
                else
                {

                    DisplaedProducts = Context.Products.Where(p =>
                       p.Price >= parameters.SumFrom &&
                       p.Type == parameters.ProductType &&
                       p.Price <= parameters.SumTo).ToList();
                }
            }

            if(parameters.SortType != null)
            {
                switch (parameters.SortType)
                {
                    case SortType.PriceAsc:
                        DisplaedProducts = DisplaedProducts.OrderBy(d => d.Price).ToList();
                        break;
                    case SortType.PriceDesc:
                        DisplaedProducts = DisplaedProducts.OrderByDescending(d => d.Price).ToList();
                        break;
                    case SortType.ManufacturerAsc:
                        DisplaedProducts = DisplaedProducts.OrderByDescending(d => d.Manufacturer).ToList();
                        break;
                    case SortType.ManufacturerDesc:
                        DisplaedProducts = DisplaedProducts.OrderBy(d => d.Manufacturer).ToList();
                        break;
                }
            }

            CurrParams = parameters;


        }

    }
}