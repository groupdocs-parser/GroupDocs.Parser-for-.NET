using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GroupDocs.Parser.Gui.ViewModels
{
    abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool UpdateProperty<T>(ref T variable, T value, [CallerMemberName] string propertyName = "")
        {
            if (!object.Equals(variable, value))
            {
                variable = value;
                NotifyPropertyChanged(propertyName);
                return true;
            }
            return false;
        }
    }
}
