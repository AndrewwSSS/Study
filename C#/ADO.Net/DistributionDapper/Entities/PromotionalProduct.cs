using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionDapper.Entities
{
    public class PromotionalProduct
    {
        public int id { get; set; }
        public string ProductName { get; set; }
        public long NewPrice { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Country { get; set; }
    }
}
