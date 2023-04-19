using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace life_designer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        public MainWindowViewModel() 
        {
            
            Items = new ObservableCollection<Item>();
            СollectionInitialization(Items);


        }

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






        private RelayCommand addCategory;
        private RelayCommand removeCategory;
        private ObservableCollection<Item> _items;
        public RelayCommand AddCategory
        {
            get
            {
                return addCategory ??
                  (addCategory = new RelayCommand(obj =>
                  {
                      add_category AD = new add_category();
                      AD.Show();
                  }));
            }
        }

        public RelayCommand RemoveCategory
        {
            get
            {
                return removeCategory ??
                  (removeCategory = new RelayCommand(obj =>
                  {
                      del_category DC = new del_category();
                      DC.Show();
                  }));
            }
        }






        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
