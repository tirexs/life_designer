using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace life_designer.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {


        public event PropertyChangedEventHandler? PropertyChanged;


        public virtual void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }





    }
}
