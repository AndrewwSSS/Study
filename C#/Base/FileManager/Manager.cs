using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using FileManager.Entities;

namespace FileManager
{
    public class Manager
    {
        public Catalog root { get; set;}

        public Manager(string path)
        {
            if (Directory.Exists(path))
                root = new Catalog(path);
            else
                throw new Exception("Invalid argument");
        }
   
    
        public void ReadChildren() {
            root.ReadAllChildren();
        }

        public bool ReadFromFile(string path) {

            try {
                XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

                using (var reader = new XmlTextReader(path)){
                    root = (Catalog)serializer.Deserialize(reader);
                }
            }
            catch (Exception) {
                return false;
            }
            return true;


        }

        public bool SaveToFile(string path) {

            XmlSerializer serializer = new XmlSerializer(typeof(Catalog));

            try {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, root);
                }   
            }
            catch (Exception) {
                return false; 
            }
            return true;
        }

        public void print() {
            root.print();
        }
    }
}
