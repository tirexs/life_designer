using life_designer.ViewModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace life_designer.View
{
    /// <summary>
    /// Логика взаимодействия для add_category.xaml
    /// </summary>
    public partial class Add_category : Window
    {
        private ObservableCollection<MainWindowViewModel.Item> items;

        public Add_category()
        {
            InitializeComponent();
            
        }

        public Add_category(ObservableCollection<MainWindowViewModel.Item> items)
        {
            this.items = items;
        }
    }
}
