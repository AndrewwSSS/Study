using System.Data.Entity;
using System.Security.Policy;
using _19._02._2022.Entities;

namespace _20._02._2022.Entities.Context
{
    class TelephoneBookContext : DbContext
    {
        public TelephoneBookContext() : base("DbConnection")
        {
        }


        public void UpdateLocalData()
        {
            Contacts.Load();
            Groups.Load();
        }


        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
