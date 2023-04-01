using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace life_designer
{
    /// <summary>
    /// Логика взаимодействия для del_category.xaml
    /// </summary>
    public partial class del_category : Window
    {

        readonly SQLDataBase DataBase = new SQLDataBase();
        public del_category()
        {
            InitializeComponent();
            DataBase.OpenConnection();
        }

        private void Butten_cancle_Click(object sender, RoutedEventArgs e)
        {
            MainWindow MW = new MainWindow();
            MW.Show();
            Close();
        }

        private void Button_del_Click(object sender, RoutedEventArgs e)
        {
            string name_Category = TextBox.Text;
            SqlCommand command = new SqlCommand("DELETE FROM [Category] WHERE CategoryName = @name", DataBase.SqlConnection);
            command.Parameters.AddWithValue("name", name_Category);
            command.ExecuteNonQuery();
            MainWindow MW = new MainWindow();
            MW.Show();
            Close();
        }
    }
}
