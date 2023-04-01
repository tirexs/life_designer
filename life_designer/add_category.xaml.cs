using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace life_designer
{
    /// <summary>
    /// Логика взаимодействия для add_category.xaml
    /// </summary>
    public partial class add_category : Window
    {
      

        public add_category()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            using (var context = new DataBaseContext())
            {

                var category = new Category();
                {
                    Name = TextBox.Text;
                };

                context.Categorys.Add(category);
                context.SaveChanges();                    
            }

            MainWindow MW = new MainWindow();
            Hide();
            MW.Show();
            Close();
        }

        private void Button_cancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
