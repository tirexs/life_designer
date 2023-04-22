﻿using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using System;
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
                var mwvm = new MainWindowViewModel();
                mwvm.СollectionInitialization(mwvm.Items);
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
