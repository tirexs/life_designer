using life_designer.Commands;
using life_designer.Model;
using life_designer.View;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class Del_taskViewModel: ViewModelBase
    {


        public Del_taskViewModel() 
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
            DelTaskCommand = new RelayCommand(DelTask);
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

        public ICommand DelTaskCommand { get; private set; }

        private void DelTask(object parameter)
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {
                    var data = context.datas.Where(c => c.Text == Text).ExecuteDelete();

                    var item = ItemsCollection.Items.FirstOrDefault(i => i.Header == ItemsCollection.SelectedItem.Header);
                    if (item != null)
                    {
                        item.Content.Remove(Text);
                    }
                    CloseWindowCommand.Execute(null);
                }
            }
        }

        public ICommand CloseWindowCommand { get; private set; }

        private void CloseWindow(object parameter)
        {
            Application.Current.Windows.OfType<Del_task>().FirstOrDefault()?.Close();
        }


    }
}
