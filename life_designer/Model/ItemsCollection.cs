using life_designer.ViewModel;
using static life_designer.ViewModel.MainWindowViewModel;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using life_designer.Interface;

namespace life_designer.Model
{
    public class ItemsCollection : Tab
    {
        public ItemsCollection(string name, List<string> content)
        {
            Name = name;
            Content = content;
        }

    }
}
