namespace Task4.Pages.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public List<Book> Books { get; set; }

        public Author() {
            Books = new List<Book>();
        }
    }
}
