using System.ComponentModel.DataAnnotations.Schema;

namespace Task3.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Manufacturer { get; set; }
        public float Price { get; set; }
        public string ImgUrl { get; set; }
        public ProductType Type { get; set; }

        public Product(string name, string manufacturer, string imgUrl, int price, ProductType type, string? description = null)
        {
            Name = name;
            Description = description;
            Manufacturer = manufacturer;
            ImgUrl = imgUrl;
            Price = price;
            Type = type;
        }

        public Product() { }

    }
}
