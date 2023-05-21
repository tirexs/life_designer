using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace life_designer.Model
{
    public static class ItemsCollection 
    {
        public static ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item> ();
        public static Item SelectedItem { get; set; }
    }



    public class Item
    {
        public string Header { get; set; }
        public ObservableCollection<string> Content { get; set; }

    }
}
