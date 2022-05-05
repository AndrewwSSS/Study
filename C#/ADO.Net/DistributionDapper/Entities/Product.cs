using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionDapper.Entities
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Section { get; set; }
    }
}
