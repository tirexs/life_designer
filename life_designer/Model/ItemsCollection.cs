using System.Collections.ObjectModel;
using System.Collections.Generic;
using System;
using System.Windows.Controls;

namespace life_designer.Model
{
    public static class ItemsCollection 
    {
        public static ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item> ();
        public static TabItem SelectedItem { get; set; } = new TabItem();
    }



    public class Item
    {
        public string Header { get; set; }
        public List<string> Content { get; set; }

    }
}
