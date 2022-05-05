using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Snake.Model.Entities
{
    // Класс для упрощения использования INPC
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
