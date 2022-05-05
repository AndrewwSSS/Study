using Snake.Model;
using Snake.Model.Entities;
using Snake.Model.Entities.Enums;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Snake.VievwModel
{
    public class ViewModel : NotifyPropertyChanged
    {
        private int width;
        private int height;
        private int score;
        private ICommand moveCommand;
        private ICommand startPauseRestartCommand;
        private GameStatus gameState;
        private int tailCount;
        private readonly Game currGame;

        public MainWindow MainWindow;
        public int Width
        {
            get { return width; }
            set
            {
                width = value;

                OnPropertyChanged(nameof(Width));
                OnPropertyChanged(nameof(FieldView));
            }
        }
        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                OnPropertyChanged(nameof(Width));
                OnPropertyChanged(nameof(FieldView));
            }
        }
        public GameStatus GameState
        {
            get => gameState;
            set
            {
                gameState = value;
                OnPropertyChanged();
            }
        }
        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnPropertyChanged(nameof(Score));
            }
        }
        public int TailCount
        {
            get => tailCount;
            set
            {
                tailCount = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Cell> FieldView { get; set; } = new ObservableCollection<Cell>();
        public ICommand MoveCommand => moveCommand ??= new RelayCommand(parameter =>
        {
            if (GameState == GameStatus.Сontinues && Enum.TryParse(parameter.ToString(), out Direction direction))
                currGame.Dir = direction;
        });
        public ICommand StartPauseRestartCommand => startPauseRestartCommand ??= new RelayCommand(parameter =>
        {
            switch (GameState)
            {
                case GameStatus.Pause:
                    currGame.Start();
                    MainWindow.Button11.Content = "Pause";
                    MainWindow.BorderGamePause.Visibility = Visibility.Hidden;
                    break;
                case GameStatus.Сontinues:
                    currGame.Stop();
                    MainWindow.Button11.Content = "Play";
                    MainWindow.BorderGamePause.Visibility = Visibility.Visible;
                    break;
                case GameStatus.WaitingForRestart:
                    MainWindow.Button11.Content = "Pause";
                    currGame.Setup(40, 25);
                    GameState = GameStatus.Сontinues ;
                    MainWindow.BorderGameOver.Visibility = Visibility.Hidden;
                    currGame.Start();
                    break;

            }
        }
        );


        public ViewModel(MainWindow main) {

           
            GameState = GameStatus.Pause;
            MainWindow = main;
            currGame = new Game(this);



        }

        public void GameOver()
        {
            MainWindow.Button11.Content = "Restart";
            MainWindow.BorderGameOver.Visibility = Visibility.Visible;
            MainWindow.GOTime.Text = MainWindow.TBPastTime.Text;
            MainWindow.GOScore.Text = Score.ToString();
        }
    }
}
