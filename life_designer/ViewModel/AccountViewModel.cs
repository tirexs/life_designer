using life_designer.View;
using System.Windows.Controls;

namespace life_designer.ViewModel
{
    public class AccountViewModel : ViewModelBase
    {

        public AccountViewModel()
        {
            CurrentPage = new Login();
        }

        private Page currentPage;
        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        

    }
}
