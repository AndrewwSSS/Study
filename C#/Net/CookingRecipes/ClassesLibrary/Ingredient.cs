using System;

namespace ClassesLibrary
{
    [Serializable]
    public class Ingredient
    {
        public string Name { get;  set; }

        public Ingredient(string Name)
        { 
            this.Name = Name;
        }

        //For serialize
        public Ingredient() { }

    }
}
