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
        readonly SQLDataBase DataBase = new SQLDataBase();

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new MainPage();

            //ObservableCollection<Button> myButton = new ObservableCollection<Button>();
            DataBase.OpenConnection();
            update_myButton();
        }

        

        static public ObservableCollection<Button> myButton = new ObservableCollection<Button>
        {
            //new Button() { Height = 19.96, Width = 451, Content = "Huyovaya_Categoriya", Visibility = Visibility.Visible}
        };


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
            SqlCommand command = new SqlCommand("SELECT MAX(IdCategory) FROM [Category]", DataBase.SqlConnection);

            int numberCategory = Convert.ToInt32(command.ExecuteScalar());

            StackPanel_Category.Children.Clear();
            myButton.Clear();

            for (int i = 0; i < numberCategory; i++)
            {
                command.CommandText = $"SELECT CategoryName FROM [Category] WHERE IdCategory = {i+1}";
                string nameButton = Convert.ToString(command.ExecuteScalar());
                
                myButton.Add(new Button(){ Height = 19.96, Width = 451, Content = nameButton, Name = "ButtonCategory_"+$"{i}"});
                StackPanel_Category.Children.Add(myButton[i]);
                myButton[0].Content = "fsdf";
                
            }

        }

       
        
        private void del_category_Click(object sender, RoutedEventArgs e)
        {
            del_category DC = new del_category();
            DC.Show();
            Close();

        }
    }
}
