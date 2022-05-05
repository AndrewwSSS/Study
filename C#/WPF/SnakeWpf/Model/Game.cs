using Snake.Model.Entities;
using Snake.Model.Entities.Enums;
using Snake.VievwModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Snake.Model
{
    public class Game : NotifyPropertyChanged
    {
        private readonly int Delay = 100;

        private Direction dir;

        private CancellationTokenSource _cts = null;

        private bool drawingPassed;

        public Stopwatch SwDurationOfGame { get; set; } = new Stopwatch(); 

        public ViewModel ViewModel { get; set; }

        public List<List<Cell>> Field { get; set; } = new List<List<Cell>>();

        public Entities.Snake Snake { get; set; }

        public FoodController FoodController { get; set; }

        public Direction Dir
        {
             get { return dir; }
             set
             {
                if (value != Dir && (int)value % 2 != (int)Dir % 2 && !drawingPassed)
                {
                    dir = value;
                    drawingPassed = true;
                }
             }
        }

       
        public Game(ViewModel view)
        {
            ViewModel = view;
            ViewModel.MainWindow.Field.Opacity = 0.7;
            ViewModel.MainWindow.BorderGamePause.Visibility = Visibility.Visible;
            Setup(40, 25);

        }

        public void Setup(int fieldWidth, int fieldHeight)
        {
            if(ViewModel.GameState != GameStatus.Сontinues)
            {
                SwDurationOfGame.Reset();

                ViewModel.Width = fieldWidth;
                ViewModel.Height = fieldHeight;

                ViewModel.Score = 0;
                ViewModel.TailCount = 0;

                TimeSpan ts = SwDurationOfGame.Elapsed;
                ViewModel.MainWindow.TBPastTime.Text = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);

                Field.Clear();
                ViewModel.FieldView.Clear();

                for (int i = 0; i < fieldHeight; i++)
                {
                    List<Cell> Row = new List<Cell>();

                    for (int j = 0; j < fieldWidth; j++)
                    {
                        Cell newCell = new Cell(CellState.Empty);
                        Row.Add(newCell);
                        ViewModel.FieldView.Add(newCell);
                    }

                    Field.Add(Row);
                }

                Dir = (Direction)new Random().Next(1, 4);

                FoodController = new FoodController(Field, 1, 5);
                FoodController.Update();

                Snake = new Entities.Snake(this, new Coord(Field[0].Count / 2, Field.Count / 2), Dir);
            }
        }

        public void Start()
        {
            
            if (_cts == null)
            {
                ViewModel.MainWindow.Field.Opacity = 1;
                SwDurationOfGame.Start();
                Run();
                ViewModel.GameState = GameStatus.Сontinues;
            }
               
        }

        public void Stop() {
            SwDurationOfGame.Stop();
            if (_cts != null)
            {
                ViewModel.MainWindow.Field.Opacity = 0.7;
                ViewModel.GameState = GameStatus.Pause;
                _cts.Cancel();
                
            }
         
        }

        public async void Run() {
            using (_cts = new CancellationTokenSource())
            {
                try {
                    while (true)
                    {
                        Update();
                        await Task.Delay(Delay, _cts.Token);

                        if (drawingPassed)
                            drawingPassed = false;

                        TimeSpan ts = SwDurationOfGame.Elapsed;
                        ViewModel.MainWindow.TBPastTime.Text = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds).ToString();
                    }
                }
                catch (OperationCanceledException) { }
            }
            _cts = null;
        }

        public void Update()
        {
            switch (Snake.Move(Dir))
            {
                case SnakeMoveResult.FruitEaten:
                    ViewModel.Score += 14;
                    FoodController.OnFoodEaten();
                    ViewModel.TailCount++;
                    break;
                case SnakeMoveResult.SnakeDead:
                    Stop();
                    ViewModel.GameState = GameStatus.WaitingForRestart;
                    ViewModel.GameOver();
                    break;
            }
        }
    }
}
