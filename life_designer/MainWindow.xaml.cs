using System.Windows;
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
