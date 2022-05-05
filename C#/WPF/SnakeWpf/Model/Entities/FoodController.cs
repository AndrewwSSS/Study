using Snake.Model.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Snake.Model.Entities
{
    public class FoodController
    {
        private int countFoodOnField;

        public int CountFoodOnField { get => countFoodOnField; }
        public int MinAdd { get; set; }
        public int MaxAdd { get; set; }
        public List<List<Cell>> Field { get; set; }
        public Random Random = new Random();
        public FoodController(List<List<Cell>> cells, int minAddFood, int maxAddFood)
        {
            Field = cells;
            MinAdd = minAddFood;
            MaxAdd = maxAddFood;

        }

        public void Update()
        {
            int count = 0;
            int needFood = new Random().Next(MinAdd, MaxAdd);
            while (true)
            {
                int y = Random.Next(0, Field.Count - 1);
                int x = Random.Next(0, Field[0].Count - 1);

                if(Field[y][x].State == CellState.Empty)   {
                    Field[y][x].State = CellState.Food;
                    count++;
                    if (count == needFood)
                        break;
                }
                

            }
            countFoodOnField = needFood;

        }

        public void OnFoodEaten() {
            if(--countFoodOnField == 0)
                Update();
        }
    }
}
