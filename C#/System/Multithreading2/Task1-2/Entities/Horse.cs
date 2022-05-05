using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace Task1_2.Entities
{
    public class Horse : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public int CurrProgress
        {
            get { return currProgress; }
            set
            {
                currProgress = value;
                OnPropertyChanged("CurrProgress");
            }
        }
        private int currProgress { get; set; } = 0;
        public int MaxProgress { get; set; }
        public int MinMove { get; set; }
        public int MaxMove { get; set; }
        public SolidColorBrush BackgroundColor { get; set; }
        public bool isFinished
        {
            get { return currProgress == MaxProgress; }
        }
        public bool isFirstMove { get; set; } = true;

        public TimeSpan СheckInTime;

        public Horse(string Name, int MaxProgress, int MinMove, int MaxMove)
        {
            this.Name = Name;
            this.MaxProgress = MaxProgress;
            this.MinMove = MinMove;
            this.MaxMove = MaxMove;

        }
        public void NextMove(Random random, Stopwatch stopwatch)
        {
            if (!isFinished)
            {
                int MoveLength = random.Next(MinMove, MaxMove);

                if (MoveLength + CurrProgress >= MaxProgress) {
                    CurrProgress = MaxProgress;
                    СheckInTime = stopwatch.Elapsed;
                }
                else
                    CurrProgress += MoveLength;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
