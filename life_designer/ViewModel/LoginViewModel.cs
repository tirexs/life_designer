using life_designer.Infrastructure;
using life_designer.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {

        public LoginViewModel() 
        {
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);


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

        public ICommand LoginCommand { get; private set; }

        private void Login(object parameter)
        {

        }

        public ICommand RegisterCommand { get; private set; }

        private void Register(object parameter)
        {
            Register register = new Register();
            register.Show();
        }
    }
}
