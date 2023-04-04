using System.Collections.ObjectModel;
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




        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<Item>
            {
                new Item { Header = "One", Content = "One's content" }
             
            };
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
