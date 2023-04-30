using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace life_designer.Model
{
    public static class ItemsCollection 
    {
        public static ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item> ();
    }



    public class Item
    {
        public string Name { get; set; }
        public List<string> Content { get; set; }

    }
}
