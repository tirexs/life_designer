using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using life_designer.page;

namespace life_designer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();

        }

        

        private void Button_Cprivet_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate( new page.Page1());
           
        }

        private void Button_Chome_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new page.Page2());
        }

        private void Button_Cwork_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new page.Page3());
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
}
