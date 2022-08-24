using System.Xml.Serialization;
using Task3.Pages;

namespace Task3.Entities
{
    public class UsersDb
    {
        private static UsersDb? instance;
        public UsersDb Instance
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
        public List<User>? Users { get; set; }
        public string Path { get; set; }

        public UsersDb(string path) => Path = path;
        public UsersDb() { }


        public void Load()
        {

            XmlSerializer serializer = new(typeof(List<User>));

            try
            {
                using (StreamReader sr = new(Path))
                {
                    object? tmp = serializer.Deserialize(sr);
                    if (tmp != null && tmp is List<User>)
                        Users = (List<User>)tmp;
                }
            }
            catch (Exception)
            {
                Users = new();
            }


        }

        public void Save()
        {
            XmlSerializer serializer = new(typeof(List<User>));

            try
            {
                if (Users != null && Users.Count > 0)
                {
                    using (StreamWriter sw = new(Path))
                    {
                        serializer.Serialize(sw, Users);
                    }
                }

            }
            catch (Exception) { }

        }
    }
}
