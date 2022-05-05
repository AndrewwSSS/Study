
namespace DistributionDapper.Entities
{
    public class Section
    {
        public int id { get; set; }
        public string Name { get; set; }

        public override string ToString() => Name;
    }
}
