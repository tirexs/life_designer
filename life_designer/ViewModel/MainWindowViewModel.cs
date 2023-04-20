using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace life_designer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel() 
        {
            
            Items = new ObservableCollection<Item>();
            СollectionInitialization(Items);
            RemoveCategoryCommand = new RelayCommand(RemoveCategory);
            AddCategoryCommand = new RelayCommand(AddCategory);

        }

        private ObservableCollection<Item> _items;
        public ObservableCollection<Item> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        public sealed class Item
        {
            public string Header { get; set; }
            public List<string> Content { get; set; }
        }

        public void СollectionInitialization(ObservableCollection<Item> Items)
        {
            using (var context = new DataBaseContext())
            {
                Items.Clear();
                var category = context.Categorys.Select(n => n.Name).ToList();

                foreach (var Cname in category)
                {
                    var id = context.Categorys.Where(n => n.Name == Cname).Select(n => n.Id);
                    var contents = context.datas.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Text).ToList();
                    Items.Add(new Item { Header = Cname, Content = contents });
                }
            }
        }






        public ICommand AddCategoryCommand { get; private set; }

        private void AddCategory(object parameter)
        {
            using (var context = new DataBaseContext())
            {
                Add_category AD = new Add_category();
                AD.Show();
            }
        }


        public ICommand RemoveCategoryCommand { get; private set; }

        private void RemoveCategory(object parameter)
        {
            using (var context = new DataBaseContext())
            {
                Del_category DC = new Del_category();
                DC.Show();
            }
        }






        
    }
}
