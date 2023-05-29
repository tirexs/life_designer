using life_designer.Commands;
using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.Stores;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        private string errText;
        public string ErrText
        {
            get { return errText; }
            set
            {
                errText = value;
                OnPropertyChanged("ErrText");
            }
        }

        private string errNullText;
        public string ErrNullText
        {
            get { return errNullText; }
            set
            {
                errNullText = value;
                OnPropertyChanged("ErrNullText");
            }
        }

        private string errNulText;
        public string ErrNulText
        {
            get { return errNulText; }
            set
            {
                errNulText = value;
                OnPropertyChanged("ErrNulText");
            }
        }

        public ICommand CICommand { get; }

        public ICommand NavigateRegisterCommand { get; }

        public ICommand NavigateUserPanelCommand { get; }
        
        public ICommand LoginCommand { get; private set; }

        private void Login(object parameter)
        {
            if (PassText == null || EmailText == null || PassText == "" || EmailText == "")
            {
                if (EmailText == null || EmailText == "")
                    ErrNullText = "Обязательно для заполнения";
                if (PassText == null || PassText == "")
                    ErrNulText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var CurrentUser = context.userLogins.FirstOrDefault(u => u.Email == EmailText && u.Password == MD5Hash.hashPassword(PassText));
                    if (CurrentUser != null)
                    {
                        ItemsCollection.IdUser = CurrentUser.Id;
                        CICommand.Execute(null);
                        NavigateUserPanelCommand.Execute(null);
                    }
                    else
                    {
                        ErrText = "Неверный логин или пароль";
                        EmailText = "";
                        PassText = "";
                    }
                }
            }
        }
    }
}
