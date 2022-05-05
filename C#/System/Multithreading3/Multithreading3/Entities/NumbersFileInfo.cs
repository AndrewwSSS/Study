using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Multithreading3.Entities
{
    public class NumbersFileInfo
    {
        public string path { get; set; }
        public int AmountOfNumbers { get; set; }
        public long Length { get; set; }
        public List<int> Numbers { get; set; }
        public string Name {
            get { return Path.GetFileName(path); }
        }

        [XmlIgnore]
        public XmlSerializer serializer = new XmlSerializer(typeof(List<int>));

        public NumbersFileInfo(string path) {
            this.path = path;
        }

        public NumbersFileInfo()  {  }
        public void Read()
        {
            using(StreamReader reader = new StreamReader(path))
            {
                Numbers = (List<int>)serializer.Deserialize(reader);
                Length =  new FileInfo(path).Length;
                AmountOfNumbers = Numbers.Count;
            }
        }

    }
}
