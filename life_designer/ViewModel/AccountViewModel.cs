using life_designer.Stores;
using life_designer.View;
using System;
using System.Windows.Controls;

namespace life_designer.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {

        public AccountViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged("CurrentViewModel");
        }

    }
}
