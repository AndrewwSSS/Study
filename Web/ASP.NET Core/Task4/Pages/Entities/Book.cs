namespace Task4.Pages.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public string Style { get; set; }
        public string PublishingHouse { get; set; }
        public int YearOfPublishing { get; set; }
    }
}
