using System;
using System.Xml.Serialization;

namespace ClassesLibrary
{
    [Serializable]
    public class Streat
    {
        public string Name { get; set; }

        [XmlAttribute()]
        public int PostIndex { get; set; }

        public Streat(string Name, int PostIndex)
        {
            this.Name = Name;
            this.PostIndex = PostIndex;
        }

        public Streat() { }



    }
}
