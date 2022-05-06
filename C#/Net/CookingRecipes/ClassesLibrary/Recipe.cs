using System;
using System.Collections.Generic;

namespace ClassesLibrary
{
    [Serializable]
    public class Recipe
    {
        public string Name { get; set; }
        public List<IngredientInfo> Ingredients { get; set; } = new List<IngredientInfo>();
        public TimeSpan PreparingTime { get;  set; }
        public List<string> Steps { get; set; } = new List<string>();

        public Recipe(string Name, TimeSpan PreparingTime)
        {
            this.Name = Name;
            this.PreparingTime = PreparingTime;
        }

        public Recipe(string Name, TimeSpan PreparingTime, List<IngredientInfo> Ingredients) 
        {
            this.Name = Name;
            this.PreparingTime = PreparingTime;
            this.Ingredients = Ingredients;
        }
        
        //For serialeze
        public Recipe() { }


        public Recipe AddIngredient(IngredientInfo ingredient)
        {
            Ingredients.Add(ingredient);
            return this;
        }

        public Recipe AddIngredients(List<IngredientInfo> ingredients)
        {
            Ingredients.AddRange(ingredients);
            return this;
        }

    
    }
}
