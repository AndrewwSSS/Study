using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using _19._02._2022.Entities;

namespace _20._02._2022.Entities
{
    public class Group : INotifyPropertyChanged
    {
        private string name;

        public int id { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropChanged();
            }
        }
        public List<Contact> Contacts { get; set; } = new List<Contact>();


        public override string ToString() => Name;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChanged([CallerMemberName] string PropName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }
    }
}
