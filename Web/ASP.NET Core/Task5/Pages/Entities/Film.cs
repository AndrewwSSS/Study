using System.ComponentModel.DataAnnotations.Schema;

namespace Task5.Pages.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Producer { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
        public int PublishingYear { get; set; }


        public virtual ICollection<Seance> Seances { get; set; }

        public Film() {
            Seances = new HashSet<Seance>();
        }

    }
}
