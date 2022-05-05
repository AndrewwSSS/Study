using Snake.Model.Entities.Enums;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Snake.Model.Entities
{
    public class Cell : INotifyPropertyChanged
    {

        public Cell(CellState CState)
        {
            State = CState;
        }

        private CellState state;
        public CellState State
        {
            set
            {
                state = value;
                OnPropertyChenget();
            }

            get { return state; }
        }

        private void OnPropertyChenget([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
