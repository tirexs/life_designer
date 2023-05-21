﻿using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace life_designer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {


        public MainWindowViewModel() 
        {
            СollectionInitialization();
            RemoveCategoryCommand = new RelayCommand(RemoveCategory);
            AddCategoryCommand = new RelayCommand(AddCategory);
            AddTaskCommand = new RelayCommand(AddTask);
            DelTaskCommand = new RelayCommand(DelTask);
        }

        private Item selectedItems;
        public Item SelectedItems
        {
            get { return selectedItems; }
            set
            {
                selectedItems = value;
                TabControl_SelectionChanged();
                OnPropertyChanged("SelectedItems");
            }
        }

        void TabControl_SelectionChanged()
        {
            ItemsCollection.SelectedItem = SelectedItems;
        }

       



        public void СollectionInitialization()
        {
            using (var context = new DataBaseContext())
            {
                ItemsCollection.Items.Clear();
                var category = context.Categorys.Select(n => n.Name).ToList();

                foreach (var Cname in category)
                {
                    var id = context.Categorys.Where(n => n.Name == Cname).Select(n => n.Id);
                    var contents = context.datas.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Text).ToList();
                    ItemsCollection.Items.Add(new Item{ Header = Cname, Content = new ObservableCollection<string>(contents)});
                }
            }
        }






        public ICommand AddCategoryCommand { get; private set; }

        private void AddCategory(object parameter)
        {
            Add_category AC = new Add_category();
            AC.Show();  
        }


        public ICommand RemoveCategoryCommand { get; private set; }

        private void RemoveCategory(object parameter)
        {
            Del_category DC = new Del_category();
            DC.Show();
        }

        public ICommand AddTaskCommand { get; private set; }

        private void AddTask(object parameter)
        {
            ItemsCollection.SelectedItem = SelectedItems;
            Add_task AT = new Add_task();
            AT.Show();
        }

        public ICommand DelTaskCommand { get; private set; }

        private void DelTask(object parameter)
        {
            ItemsCollection.SelectedItem = SelectedItems;
            Del_task DT = new Del_task();
            DT.Show();
        }



    }
}
