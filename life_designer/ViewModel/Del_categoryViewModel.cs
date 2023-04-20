using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class Del_categoryViewModel : ViewModelBase
    {

        public Del_categoryViewModel() 
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
            RemoveCategoryCommand = new RelayCommand(RemoveCategory);
        }

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public ICommand RemoveCategoryCommand { get; private set; }

 
        private void RemoveCategory(object parameter)
        {
            using (var context = new DataBaseContext())
            {
                var category = context.Categorys.Where(c => c.Name == Text).ExecuteDelete();
                CloseWindowCommand.Execute(null);
            }
        }

        public ICommand CloseWindowCommand { get; private set; }

        private void CloseWindow(object parameter)
        {

            Application.Current.Windows.OfType<Del_category>().FirstOrDefault()?.Close();
        }
    }
}

