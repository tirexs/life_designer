using life_designer.Commands;
using life_designer.Model;
using life_designer.Stores;
using System;
using System.Linq;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class UserPanelViewModel : ViewModelBase
    {

        public UserPanelViewModel(NavigationStore navigationStore)
        {
            LogOutCommand = new RelayCommand(LogOut);
            LogOutC = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));
            Data();
        }
        public UserPanelViewModel(){}

        private string emailText;
        public string EmailText
        {
            get { return emailText; }
            set
            {
                emailText = value;
                OnPropertyChanged("EmailText");
            }
        }

        private string loginText;
        public string LoginText
        {
            get { return loginText; }
            set
            {
                loginText = value;
                OnPropertyChanged("LoginText");
            }
        }

        private string idText;
        public string IdText
        {
            get { return idText; }
            set
            {
                idText = value;
                OnPropertyChanged("IdText");
            }
        }

        public ICommand LogOutC { get; }
        public ICommand LogOutCommand { get; private set; }

        private void LogOut(object parametr)
        {
            ItemsCollection.Items.Clear();
            LogOutC.Execute(null);
        }

        void Data()
        {
            using (var Context = new DataBaseContext())
            {
                var CurrentUser = Context.userLogins.FirstOrDefault(i => i.Id == ItemsCollection.IdUser);
                if(CurrentUser != null)
                {
                    EmailText = CurrentUser.Email;
                    LoginText = CurrentUser.UserName;
                    IdText = CurrentUser.Id.ToString();
                }
            }
        }
    }
}
