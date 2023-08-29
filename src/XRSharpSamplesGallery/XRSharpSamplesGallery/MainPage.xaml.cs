using System.Windows.Controls;
using XRSharpSamplesGallery.Menu;

namespace XRSharpSamplesGallery
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            var menuViewModel = new MenuViewModel();
            menuViewModel.SelectionChanged += OnSelectionChanged;
            DataContext = menuViewModel;
        }

        private void OnSelectionChanged(object sender, Menu.MenuItem menuItem)
        {
            // Hide the menu if we are in mobile and the menu is on top of everything:
            ResponsivePaneInstance.CollapseIfMobile();
        }
    }
}
