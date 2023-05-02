using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
            //нужно добавить задачу, где категория задачаи равна SelectedItem.name
            //что нужно:
            //получить имя вкладки через SelectedItem
            //найти id в базе данных выбранной категории
            //добавить в базу данных задачу, где idcategory = найденному id
            //обновить ItemsCollection.Items
            using (var context = new DataBaseContext())
            {
                //TabItem v = ItemsCollection.SelectedItem as TabItem;
                if (ItemsCollection.SelectedItem != null)
                {
                    var b = ItemsCollection.SelectedItem.Header.ToString();
                    
                }
            }
        }

        public ICommand CloseWindowCommand { get; private set; }

        private void CloseWindow(object parameter)
        {
            Application.Current.Windows.OfType<Add_task>().FirstOrDefault()?.Close();
        }







    }
}
