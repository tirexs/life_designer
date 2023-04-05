using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace life_designer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Item> Items { get; set; }


        //TabControl table = new TabControl();

		public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<Item>
            {
                new Item { Header = "One", Content = "One's content1" },
				new Item { Header = "Two", Content = "One's content2" },
				new Item { Header = "Tri", Content = "One's content3" }
            };

            foreach(var item in Items)
            {
				table.Items.Add(item);
			}

		}

        

        
       
        private void add_category_Click(object sender, RoutedEventArgs e)
        {

            add_category AC = new add_category();
            AC.Show();
            Close();
        }

        

        void update_myButton()
        {
           

        }

       
        
        private void del_category_Click(object sender, RoutedEventArgs e)
        {
            del_category DC = new del_category();
            DC.Show();
            Close();

        }
    }


    public sealed class Item
    {
        public string Header { get; set; }
        public string Content { get; set; }
    }


}
