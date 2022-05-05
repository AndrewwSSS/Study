using ParseNewPost.Data.Entitis;
using ParseNewPost.Data.HelpClasses;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using static System.Console;

namespace ParseNewPost.Data
{
    public class DbContext
    {

        public List<City> cities = new();
        public List<Area> Areas { get; set; } = new List<Area>();

        public string xmlIncomingArea = @".\..\..\..\areas.xml";
        public string XmlIncomingCities = @".\..\..\..\cities\";

        public void print() {
            WriteLine("The number of villages: " + cities.Count(city => city.SettlementTypeDescriptionRu == "село"));
            WriteLine("The number of settlements in which departments do not work on weekdays:" + cities.Count(city =>  (city.Delivery1 + city.Delivery2 + city.Delivery3 + city.Delivery4 + city.Delivery5 ) == 0));
            WriteLine("The number of settlements in which departments work on Saturdays, but not on Sundays: " + cities.Count(city => city.Delivery6 == 1 && city.Delivery7 == 0));
        }

        public void GetAreasFromFile()
        {

            XmlTextReader reader = new XmlTextReader(xmlIncomingArea);
            while(reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        if(reader.Name == "item")
                        {
                            Area area = new Area();
                            bool isFinish = false;
                            int endElem = 0;

                            do
                            {
                               
                                reader.Read();
                                switch (reader.NodeType)
                                {
                                
                                    case XmlNodeType.Element:
                                        string name = reader.Name;
                                        reader.Read();

                                        area.GetType().GetProperty(name).SetValue(area, reader.Value);
                                        break;
                                   
                                    case XmlNodeType.EndElement:
                                        endElem++;
                                        isFinish = (endElem > 4) ? true: false;
                                        break;
                                }
 
                            } while (!isFinish);
                            Areas.Add(area); 
                        }
                        break;
                }
            }

        }

        public void GetCitiesFromFile()
        {
             DirectoryInfo dir = new DirectoryInfo(XmlIncomingCities);
             FileInfo[] files = dir.GetFiles().Where(f => f.Extension == ".xml").ToArray();
             XmlSerializer serializer = new XmlSerializer(typeof(HelpCities));

             foreach (var item in files) 
             {
                 using(FileStream fs = new FileStream(item.FullName, FileMode.Open))
                 {
                     HelpCities city = new HelpCities();
                     city = (HelpCities)serializer.Deserialize(fs);

                     if (city.data.item != null)
                        cities.AddRange(city.data.item.ToList());

                     foreach (var area in Areas)
                         if(city.data.item != null)
                            area.cities.AddRange(city.data.item.Where(c => c.Area == area.Ref)); }
             }
        }

        public void Run()
        {
            GetAreasFromFile();
            GetCitiesFromFile();
            print();
        }

    }
}
