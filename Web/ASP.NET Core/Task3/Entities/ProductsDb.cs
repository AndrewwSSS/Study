using System.Xml.Serialization;

namespace Task3.Entities
{
    public class ProductsDb
    {
        private static ProductsDb? instance;
        public ProductsDb Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new(Path);
                    instance.Load();
                }


                return instance;
            }
        }


        public string Path { get; set; }
        public List<Product>? Products { get; set; }

        public ProductsDb(string path)
        {
            Path = path;
        }

        public ProductsDb() { }

        public void Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {

                    object? res = serializer.Deserialize(sr);

                    if (res != null && res is List<Product>)
                    {
                        Products = (List<Product>)res;
                    }
                }
            }
            catch (Exception) { }




        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));

            try
            {
                if (Products != null && Products.Count > 0)
                {
                    using (StreamWriter sw = new StreamWriter(Path))
                        serializer.Serialize(sw, Products);
                }
            }
            catch (Exception) { }


        }

        public Product? GetProductById(int Id)
        {
            if (Products != null)
                return Products.FirstOrDefault(p => p.Id == Id);
            return null;

        }

    }
}
