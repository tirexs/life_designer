using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
                Items.Clear();
                var category = context.Categorys.Select(n => n.Name).ToList();

                foreach (var Cname in category)
                {
                    var id = context.Categorys.Where(n => n.Name == Cname).Select(n => n.Id);
                    var contents = context.datas.Include(t => t.Category).Where(t => t.IdCategory == id.First()).Select(x => x.Text).ToList();
                    AddToCollection(Cname, contents);
                }              
            }
        }



        public static void AddToCollection(string n, List<string> t)
        {
            Items.Add(new Item { Header = n, Content = t});
        }



        public sealed class Item
        {
            public string Header { get; set; }
            public List<string> Content { get; set; }
        }

    }
}
