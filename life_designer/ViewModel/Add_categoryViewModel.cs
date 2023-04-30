using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using static life_designer.ViewModel.MainWindowViewModel;

namespace life_designer.ViewModel
{
    public class Add_categoryViewModel : ViewModelBase
    {
        

        public Add_categoryViewModel()
        {
            
            CloseWindowCommand = new RelayCommand(CloseWindow);
            AddCategoryCommand = new RelayCommand(AddCategory);
        }

        public Add_categoryViewModel(ObservableCollection<MainWindowViewModel.Item> items)
        {
            this.items = items;
        }

        private string text;
        ObservableCollection<MainWindowViewModel.Item> items { get; set; }

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

       


        public ICommand AddCategoryCommand { get; private set; }

        private void AddCategory(object parameter)
        {
            using (var context = new DataBaseContext())
            {

                var category = new Category()
                {
                    Name = Text
                };

                context.Categorys.Add(category);
                context.SaveChanges();
                items.Add(new Item { Header = Text, Content = new List<string>() });
                CloseWindowCommand.Execute(null);
            }
        }

        public ICommand CloseWindowCommand { get; private set; }

        private void CloseWindow(object parameter)
        {            
            Application.Current.Windows.OfType<Add_category>().FirstOrDefault()?.Close();
        }
    }
}
