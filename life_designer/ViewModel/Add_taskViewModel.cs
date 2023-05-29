using life_designer.Commands;
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

        public ICommand AddTaskCommand { get; private set; }

        private void AddTask(object parameter)
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            { 
                using (var context = new DataBaseContext())
                {
                    var id = context.Categorys.Where(n => n.Name == ItemsCollection.SelectedItem.Header).Select(n => n.Id).FirstOrDefault();
                    var data = new Data()
                    {
                        Text = Text,
                        IdCategory = id,
                        IdUser = ItemsCollection.IdUser
                    };
                    context.datas.Add(data);
                    context.SaveChanges();

                    var item = ItemsCollection.Items.FirstOrDefault(i => i.Header == ItemsCollection.SelectedItem.Header);
                    if (item != null)
                    {
                        item.Content.Add(Text);
                    }
                    CloseWindowCommand.Execute(null);
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
