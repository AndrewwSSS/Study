using System.ComponentModel.DataAnnotations.Schema;

namespace Task3.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }

        public User() { }
    };
}
