using Microsoft.EntityFrameworkCore;

namespace Task4.Pages.Entities
{
    public class BooksContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        public BooksContext(DbContextOptions<BooksContext> options)
         : base(options)
        {

            Database.EnsureCreated();

            if(Books.ToList().Count == 0)
            {
                var authors = new List<Author> {
                        new Author()
                        {

                            Name = "Andjey",
                            Surname = "Sapkovskiy",
                            Patronymic = "1"
                        },
                        new Author()
                        {

                            Name = "Joanne",
                            Surname = "Rowling",
                            Patronymic = "2"
                        }
                };
                var books = new List<Book>
                {
                    new Book()
                    {

                        ImgUrl = "https://i.pinimg.com/736x/1e/3a/9d/1e3a9d051aaa41720c75dcecd6da15d5--html-book.jpg",
                        Name = "Vedmak poslednee gelanie",
                        Style = "Fantasy",
                        YearOfPublishing = 1993,
                        PublishingHouse = "Publishing house 1"
                    },
                    new Book()
                    {
                        ImgUrl = "https://assets.thalia.media/img/artikel/ffd5dd40bb9055704702a2320272f68e9b8b1f41-00-00.jpeg",
                        Name = "Harry potter 1",
                        Style = "Fantasy",
                        YearOfPublishing = 1997,
                        PublishingHouse = "Publishing house 2"
                    },
                };

             


                authors[0].Books.Add(books[0]);
                authors[1].Books.Add(books[1]);

                books[0].Author = authors[0];
                books[1].Author = authors[1];

                Authors.AddRange(authors);
                Books.AddRange(books);

                SaveChanges();

            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
                .HasMany(b => b.Books)
                .WithOne(b => b.Author);

        }

    }
}
