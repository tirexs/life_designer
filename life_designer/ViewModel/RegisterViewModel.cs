using life_designer.Commands;
using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.Stores;
using System.Linq;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {

        public RegisterViewModel(NavigationStore navigationStore)
        {
            RegisterCommand = new RelayCommand(Register);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navigationStore, () => new LoginViewModel(navigationStore));

        }
        public RegisterViewModel() { }

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

        private string errNulllText;
        public string ErrNulllText
        {
            get { return errNulllText; }
            set
            {
                errNulllText = value;
                OnPropertyChanged("ErrNulllText");
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

        public ICommand NavigateLoginCommand { get; }
        public ICommand RegisterCommand { get; private set; }

        private void Register(object parameter)
        {

            if (LoginText == null || PassText == null || EmailText == null)
            {
                if (LoginText == null)
                    ErrNullText = "Обязательно для заполнения";
                if (EmailText == null)
                    ErrNulllText = "Обязательно для заполнения";
                if (PassText == null)
                    ErrNulText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var CurrentUser = context.userLogins.FirstOrDefault(e => e.Email == EmailText);
                    if (CurrentUser != null)
                    {
                        ErrText = "Пользователь с таким Email уже зарегистрирован";
                    }
                    else
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
    }
}
