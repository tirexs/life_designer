using System.Collections.ObjectModel;
using System.Linq;

namespace life_designer
{
    public static class ItemsCollection
    {
        public static ObservableCollection<Item> Items { get; set; } = new ObservableCollection<Item>();



        public static void СollectionInitialization()
        {
            using (var context = new DataBaseContext())
            {

                var category = context.Categorys.Select(n => n.Name).ToList();
                Items.Clear();
                foreach (var item in category)
                {
                    AddToCollection(item);
                }

            }
        }



        public static void AddToCollection(string n)
        {
            Items.Add(new Item { Header = n, Content = "One's content1" });
        }



        public sealed class Item
        {
            public string Header { get; set; }
            public string Content { get; set; }
        }

    }
}
