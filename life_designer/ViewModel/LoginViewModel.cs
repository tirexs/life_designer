using life_designer.Commands;
using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.Stores;
using System.Linq;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public LoginViewModel(NavigationStore navigationStore) 
        {
            LoginCommand = new RelayCommand(Login);
            NavigateRegisterCommand = new NavigateCommand<RegisterViewModel>(navigationStore, () => new RegisterViewModel(navigationStore));
            NavigateUserPanelCommand = new NavigateCommand<UserPanelViewModel>(navigationStore, () => new UserPanelViewModel(navigationStore));
            CICommand = new СollectionInitializationCommand();
        }
        public LoginViewModel(){}

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

        private string passText;
        public string PassText
        {
            get { return passText; }
            set
            {
                passText = value;
                OnPropertyChanged("PassText");
            }
        }

        public ICommand CICommand { get; }

        public ICommand NavigateRegisterCommand { get; }

        public ICommand NavigateUserPanelCommand { get; }
        
        public ICommand LoginCommand { get; private set; }

        private void Login(object parameter)
        {
            using (var context = new DataBaseContext())
            {
                var CurrentUser = context.userLogins.FirstOrDefault(u => u.UserName == LoginText && u.Password  == MD5Hash.hashPassword(PassText));
                if(CurrentUser != null)
                {
                    ItemsCollection.IdUser = CurrentUser.Id;
                    CICommand.Execute(null);
                    NavigateUserPanelCommand.Execute(null);
                }
            }
        }

        

    }
}
