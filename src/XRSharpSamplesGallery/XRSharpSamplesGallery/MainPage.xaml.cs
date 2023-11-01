using System;
using System.Windows;
using System.Windows.Controls;
using XRSharpSamplesGallery.Menu;
using XRSharpSamplesGallery.Other;

namespace XRSharpSamplesGallery
{
    public partial class MainPage : Page
    {
        private readonly CameraAnimation _cameraAnimation;
        private readonly MenuViewModel _menuViewModel;

        public MainPage()
        {
            InitializeComponent();

            _menuViewModel = new MenuViewModel();
            _menuViewModel.SelectionChanged += OnSelectionChanged;
            DataContext = _menuViewModel;

            _cameraAnimation = new CameraAnimation(Root3DInstance);
        }

        private void OnSelectionChanged(object sender, Menu.MenuItem menuItem)
        {
            // Hide the panel that shows the Source Code when navigating:
            ViewSourcePane.Collapse();

            // Hide the menu when navigating if we are on mobile:
            MenuResponsivePane.CollapseIfMobile();

            _cameraAnimation.Animate(menuItem.CameraOptions);
        }

        private void OnEnterXR(object sender, EventArgs e)
        {
            Menu3DInstance.Visibility = Visibility.Visible;
        }

        private void OnExitXR(object sender, EventArgs e)
        {
            Menu3DInstance.Visibility = Visibility.Collapsed;
        }

        private void OnAllNodesLoaded(object sender, EventArgs e)
        {
            LodingText.Visibility = Visibility.Collapsed;
            MenuResponsivePane.Visibility = Visibility.Visible;
            ViewSourcePane.Visibility = Visibility.Visible;

            _menuViewModel.SelectedMenuItem = _menuViewModel.MenuItems[0];

            if (Root3DInstance.IsHeadsetConnected && !Root3DInstance.IsMobile)
            {
                ViewSourcePane.ButtonViewSource.HorizontalAlignment = HorizontalAlignment.Right;
            }
        }
    }
}
