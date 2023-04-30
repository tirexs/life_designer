using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class Add_taskViewModel : ViewModelBase
    {


        public Add_taskViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
            AddTaskCommand = new RelayCommand(AddTask);
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

        public ICommand AddTaskCommand { get; private set; }

        private void AddTask(object parameter)
        {
            using (var context = new DataBaseContext())
            {

                
            }
        }

        public ICommand CloseWindowCommand { get; private set; }

        private void CloseWindow(object parameter)
        {
            Application.Current.Windows.OfType<Add_task>().FirstOrDefault()?.Close();
        }







    }
}
