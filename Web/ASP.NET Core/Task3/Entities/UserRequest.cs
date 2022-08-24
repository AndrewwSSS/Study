namespace Task3.Entities
{
    public record class UserRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public UserRequest() { }

    }
}
