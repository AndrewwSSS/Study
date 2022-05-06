using System;


namespace ClassesLibrary
{

    [Serializable]
    public class IngredientInfo
    {

        public Ingredient Ingredient { get;  set; }
       
        public int Weight { get;  set; }
        
        public IngredientInfo(Ingredient Ingredient, int Weight)
        {
            this.Ingredient = Ingredient;
            this.Weight = Weight;
        }

        // for serialize
        public IngredientInfo() { }

    }
}
