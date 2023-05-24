using life_designer.Commands;
using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.Stores;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {

        public RegisterViewModel(NavigationStore navigationStore) 
        {
            RegisterCommand = new RelayCommand(Register);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, ()=> new LoginViewModel(navigationStore));

        }
        public RegisterViewModel(){}

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

        public ICommand NavigateLoginCommand { get; }
        public ICommand RegisterCommand { get; private set; }

        private void Register(object parameter)
        {
            using (var context = new DataBaseContext())
            {

                var userLogin = new UserLogin()
                {
                    UserName = LoginText,
                    Email = EmailText,
                    Password = MD5Hash.hashPassword(PassText)
                };

                context.userLogins.Add(userLogin);
                context.SaveChanges();
                NavigateLoginCommand.Execute(null);
            }
        }
    }
}
