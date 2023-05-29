using life_designer.Commands;
using life_designer.Model;
using life_designer.View;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class Add_categoryViewModel : ViewModelBase
    {

        public Add_categoryViewModel()
        {
            CloseWindowCommand = new RelayCommand(CloseWindow);
            AddCategoryCommand = new RelayCommand(AddCategory);
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

        public ICommand AddCategoryCommand { get; private set; }

        private void AddCategory(object parameter)
        {
            if (Text == null || Text == "")
            {
                ErrText = "Обязательно для заполнения";
            }
            else
            {
                using (var context = new DataBaseContext())
                {

                    var category = new Category()
                    {
                        Name = Text,
                        IdUser = ItemsCollection.IdUser
                    };

                    context.Categorys.Add(category);
                    context.SaveChanges();
                    ItemsCollection.Items.Add(new Item { Header = Text, Content = new ObservableCollection<string>() });
                    CloseWindowCommand.Execute(null);
                }
            }        
        }

        public ICommand CloseWindowCommand { get; private set; }

        private void CloseWindow(object parameter)
        {            
            Application.Current.Windows.OfType<Add_category>().FirstOrDefault()?.Close();
        }
    }
}
