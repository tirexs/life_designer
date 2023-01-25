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


        readonly SQLDataBase DataBase = new SQLDataBase();

        public add_category()
        {
            InitializeComponent();
            DataBase.OpenConnection();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT MAX(IdCategory) FROM [Category]", DataBase.SqlConnection);

            int number_Category = Convert.ToInt32(command.ExecuteScalar());
            string name_Category = TextBox.Text;
           
            command.CommandText = "INSERT INTO [Category] (CategoryName) VALUES (@CategoryName)";
            command.Parameters.AddWithValue("CategoryName", name_Category);
            command.ExecuteNonQuery();
            
            
            MainWindow.myButton.Add(new Button() { Height = 19.96, Width = 451, Content = name_Category, Name = "ButtonCategory_" + $"{number_Category}" });
            
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
