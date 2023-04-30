using life_designer.Infrastructure;
using life_designer.Model;
using life_designer.View;
using Microsoft.EntityFrameworkCore;
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
                    ItemsCollection.Items.Add(new Item{Name = Cname, Content = contents});
                }
            }
        }






        public ICommand AddCategoryCommand { get; private set; }

        private void AddCategory(object parameter)
        {
            //Tabs.Add(new ItemsCollection("alkjlksd", new List<string>()));
            Add_category AD = new Add_category();
            AD.Show();
            
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
