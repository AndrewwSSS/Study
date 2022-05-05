using Snake.Model.Entities.Enums;
using System.Collections.Generic;


namespace Snake.Model.Entities
{
    public class Snake : NotifyPropertyChanged
    {
        private Coord head;

        public Coord Head
        {
            get => head;
            set
            {
                head = value;
                Field[value.Y][value.X].State = CellState.SnakeHead;
                OnPropertyChanged();
            }
        }

        public List<Coord> Tail { get; } = new List<Coord>();

        public List<List<Cell>> Field { get; set; }

        public Snake(Game game, Coord coordHead, Direction dir)
        {
            Field = game.Field;

            Head = coordHead;
            Field[Head.Y][Head.X].State = CellState.Empty;
            Tail.Add(new Coord(Head.Y, Head.X));
            Head = GetNextCoord(dir);
        }

        public SnakeMoveResult Move(Direction dir)
        {
            Coord nextCoord = GetNextCoord(dir);

            if (nextCoord.X > Field[0].Count - 1 || nextCoord.X < 0 || nextCoord.Y > Field.Count - 1 || nextCoord.Y < 0
                || Field[nextCoord.Y][nextCoord.X].State == CellState.SnakeTail)
            {
                return SnakeMoveResult.SnakeDead;
            }

            Coord lastCoordHead = new Coord(Head.X, Head.Y);
           
            if (Field[nextCoord.Y][nextCoord.X].State == CellState.Food)
            {
                Head = GetNextCoord(dir);
                Tail.Insert(0, lastCoordHead);
                Field[lastCoordHead.Y][lastCoordHead.X].State = CellState.SnakeTail;
                return SnakeMoveResult.FruitEaten;
            }


            Head = nextCoord;

            if (Tail.Count == 0)
                Field[lastCoordHead.Y][lastCoordHead.X].State = CellState.Empty;
            else
            {
                if (Tail.Count > 0)
                {
                    Coord LastElement = Tail[Tail.Count - 1];
                    Field[LastElement.Y][LastElement.X].State = CellState.Empty;
                    Field[lastCoordHead.Y][lastCoordHead.X].State = CellState.SnakeTail;

                    Tail.RemoveAt(Tail.Count - 1);
                    Tail.Insert(0, lastCoordHead);
                }

               
            }
            return SnakeMoveResult.Moved;
        }

        public Coord GetNextCoord(Direction dir)  
        {
            Coord result = new Coord(Head.X, Head.Y);
            switch (dir)
            {
                case Direction.Left:
                    result.X--;
                    break;
                case Direction.Down:
                    result.Y++;
                    break;
                case Direction.Right:
                    result.X++;
                    break;
                case Direction.Up:
                    result.Y--;
                    break;
            }

            return result;
        } 

   
    }
}
