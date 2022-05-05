using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _19._02._2022.Entities
{
    public class Contact : INotifyPropertyChanged
    {
        private string firstName;
        private string secondName;
        private string telephone;
        private string mail;
        private DateTime birthDate;
        private int priority;
        private bool isBlocked;
        private _20._02._2022.Entities.Group group;



        public int id { get; set; }
        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropChanged();
                OnPropChanged("FullName");
            }
        }
        public string SecondName
        {
            get=> secondName;
            set
            {
                secondName = value;
                OnPropChanged();
                OnPropChanged("FullName");
            }
        }
        public string Telephone
        {
            get=>telephone;
            set
            {
                telephone = value;
                OnPropChanged();
            }
        }
        public string Mail
        {
            get=>mail;
            set
            {
                mail = value;
                OnPropChanged();
            }
        }
        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropChanged();
            }
        }
        public int Priority
        {
            get=>priority;
            set
            {
                priority = value;
                OnPropChanged();
            }
        }
        public bool IsBlocked
        {
            get=>isBlocked;
            set
            {
                isBlocked = value;
                OnPropChanged();
            }
        }
        public _20._02._2022.Entities.Group Group
        {
            get => group;
            set
            {
                
                group = value;
                OnPropChanged();
            }
        }
        public string FullName
        {
            get => firstName + " " + secondName;
        }

        public override string ToString() => FullName;
      

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
