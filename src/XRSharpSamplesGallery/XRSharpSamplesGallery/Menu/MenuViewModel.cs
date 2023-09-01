using System;
using System.ComponentModel;

namespace XRSharpSamplesGallery.Menu
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<MenuItem> SelectionChanged;

        public MenuItems MenuItems { get; } = new MenuItems();

        private MenuItem _selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged(nameof(SelectedMenuItem));
                SelectionChanged?.Invoke(this, SelectedMenuItem);
                CreateContent();
            }
        }

        private object _content;
        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public MenuViewModel()
        {
        }

        private void CreateContent()
        {
            Type type = SelectedMenuItem.PageToNavigateTo;
            Content = Activator.CreateInstance(type);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
