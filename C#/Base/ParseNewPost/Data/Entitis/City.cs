using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseNewPost.Data.Entitis
{
    public class City
    {
        public string Ref { get; set; }
        public string DescriptionRu { get; set; }
        public string Description { get; set; }

        public int Delivery1 { get; set; }
        public int Delivery2 { get; set; }
        public int Delivery3 { get; set; }
        public int Delivery4 { get; set; }
        public int Delivery5 { get; set; }
        public int Delivery6 { get; set; }
        public int Delivery7 { get; set; }

        public string Area { get; set; }

        public string SettlementType { get; set; }
        public string IsBranch { get; set; }
        public string PreventEntryNewStreetsUser { get; set; }
        public string CityID { get; set; }
        public string SettlementTypeDescription { get; set; }
        public string SettlementTypeDescriptionRu { get; set; }
        public string SpecialCashCheck { get; set; }
        public string AreaDescription { get; set; }
        public string AreaDescriptionRu { get; set; }
        public List<Departament> departaments { get; set; } = new List<Departament>();
    }
}
