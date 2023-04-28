using life_designer.Infrastructure;
using life_designer.Interface;
using life_designer.Model;
using life_designer.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel() 
        {
            tabs = new ObservableCollection<ITab>();
            tabs.CollectionChanged += TabsCollectionChanged;
            Tabs = tabs;
            СollectionInitialization();
            RemoveCategoryCommand = new RelayCommand(RemoveCategory);
            AddCategoryCommand = new RelayCommand(AddCategory);

        }

        private void TabsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            ITab tab;

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add: // если добавление
                    tab = (ITab)e.NewItems[0];
                    break;
            }
        }

        private readonly ObservableCollection<ITab> tabs;

        public ICollection<ITab> Tabs { get; }



        public void СollectionInitialization()
        {
            using (var context = new DataBaseContext())
            {
                Tabs.Clear();
                var category = context.Categorys.Select(n => n.Name).ToList();

                foreach (var Cname in category)
                {
                    var id = context.Categorys.Where(n => n.Name == Cname).Select(n => n.Id);
                    var contents = context.datas.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Text).ToList();
                    Tabs.Add(new ItemsCollection (Cname, contents));
                }
            }
        }






        public ICommand AddCategoryCommand { get; private set; }

        private void AddCategory(object parameter)
        {
            Tabs.Add(new ItemsCollection("alkjlksd", new List<string>()));
            //using (var context = new DataBaseContext())
            //{
            //    Add_category AD = new Add_category();
            //    AD.Show();
            //}
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
