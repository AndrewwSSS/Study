using System.Xml.Serialization;

namespace ParseNewPost.Data.HelpClasses
{
    public class HelpData {

        [XmlElement("item")]
        public Entitis.City[] item { get; set; }
    }

    [XmlRoot("root")]
    public class HelpCities {
        public HelpData data { get; set; }
    }

}
