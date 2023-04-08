using System.Windows;
using System.Windows.Controls;

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

                var category = new Category()
                {
                    Name = TextBox.Text
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
            MainWindow MW = new MainWindow();
            Hide();
            MW.Show();
            Close();
        }

    }
}
