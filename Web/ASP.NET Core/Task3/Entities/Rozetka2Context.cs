using Microsoft.EntityFrameworkCore;
using Task3.Pages;

namespace Task3.Entities
{

    public class Rozetka2Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public Rozetka2Context(DbContextOptions<Rozetka2Context> options)
            : base(options)
        {
         
            Database.EnsureCreated();
            if (Users.ToList().Count == 0) {
                Users.AddRange(new UsersDb("Users.xml").Instance.Users);
                SaveChanges();
            }

            if (Products.ToList().Count == 0) {
                Products.AddRange(new ProductsDb("products.xml").Instance.Products);
                SaveChanges();
            }

        }
    }
}
