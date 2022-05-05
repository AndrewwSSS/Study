using System;
using System.Data.Linq.Mapping;

namespace _12._02._2022.Entities
{
    [Table(Name = "Countries")]
    public class Country
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column()]
        public string Name { get; set; }


        [Column()]
        public string NameOfCapital { get; set; }

        [Column()]
        public int Population { get; set; }

        [Column()]
        public int Area { get; set; }

        [Column()]
        public string PartOfWorld { get; set; }

    }
}
