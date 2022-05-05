using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileManager.Entities
{
    public class Catalog
    {
        public string path { get; set; }

        public List<File> Files { get; set; } = new List<File>();

        public List<Catalog> Catalogs { get; set; } = new List<Catalog>();

        public Catalog(string path)
        {

            if (Directory.Exists(path))
                this.path = path;
            else
                throw new Exception("Invalid argument");
        }

        public Catalog() { }

        public void ReadAllChildren(Catalog Curr = null)
        {
            if (Curr == null){
                Curr = this;
            }
               

            string[] Catalogs = null;
            try
            {
                Catalogs = Directory.GetDirectories(Curr.path);
            }
            catch(Exception) {
                return;
            }


            foreach (var catalog in Catalogs)
            {
                if (Curr.Catalogs.Count(dir => dir.path == catalog) == 0)
                {
                    // I don't know how this occuring, but in something cases this func gets false
                    if(Directory.Exists(catalog))
                    {
                        Catalog newDir = new Catalog(catalog);
                        Curr.Catalogs.Add(newDir);
                        ReadAllChildren(newDir);
                    }    
                  
                }
            }
      
            foreach (var item in Directory.GetFiles(Curr.path))
            {
                if (Curr.Files.Count(file => item == (path + file.FullName)) == 0)
                    Curr.Files.Add(new File() { Name = Path.GetFileNameWithoutExtension(item), Extension = Path.GetExtension(item) });
            }
        }

        public void print(Catalog path = null, string pref = " ")
        {
            if (path == null) path = this;

            foreach (var item in path.Catalogs)
            {
                try
                {
                    Console.WriteLine(pref + (item.path));
                    print(item, pref + "\t");
                }
                catch { }
            }


            foreach (var file in path.Files)
                Console.WriteLine(pref + file.Name + file.Extension);



        }
    }
}