using life_designer.Infrastructure;
using life_designer.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace life_designer.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {

        public RegisterViewModel() 
        {
            RegisterCommand = new RelayCommand(Register);


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
                
            }
        }
    }
}
