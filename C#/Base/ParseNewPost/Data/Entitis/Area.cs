using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseNewPost.Data.Entitis
{
    public class Area
    {
        public string Ref { get; set; }
        public string AreasCenter { get; set; }
        public string DescriptionRu { get; set; }
        public string Description { get; set; }
        public List<City> cities { get; set; } = new List<City>();

    }
}
