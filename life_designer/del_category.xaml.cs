using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace life_designer
{
    /// <summary>
    /// Логика взаимодействия для del_category.xaml
    /// </summary>
    public partial class del_category : Window
    {

        
        public del_category()
        {
            InitializeComponent();
        }

        private void Butten_cancle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            Close();
        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new DataBaseContext())
            {

                var category = context.Categorys.Where(c => c.Name == TextBox.Text).ExecuteDelete();


            }


            MainWindow MW = new MainWindow();
            MW.Show();
            Close();
        }
    }
}
