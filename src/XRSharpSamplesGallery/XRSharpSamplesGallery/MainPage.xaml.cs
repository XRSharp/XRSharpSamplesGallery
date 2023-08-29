using System;
using System.Windows;
using System.Windows.Controls;
using XRSharp;
using XRSharpSamplesGallery.Samples;

namespace XRSharpSamplesGallery
{
    public partial class MainPage : Page
    {
        private readonly Point3D InitialCameraPosition;
        private readonly Point3D InitialCameraRotation;

        public MainPage()
        {
            InitializeComponent();

            this.Loaded += MainPage_Loaded;

            InitialCameraPosition = Root3DInstance.CameraPosition;
            InitialCameraRotation = Root3DInstance.CameraRotation;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Menu2DInstance.SelectedPage = typeof(Welcome);
        }

        private void Menu2D_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Instantiate the content
            Type type = Menu2DInstance.SelectedPage;
            var content = Activator.CreateInstance(type);

            // Show the content
            MainContainer.Content = content;

            // Hide the menu if we are in mobile and the menu is on top of everything:
            ResponsivePaneInstance.CollapseIfMobile();

            var menuItem = (Menu.MenuItem)Menu2DInstance.MenuListBox.SelectedItem;
            Root3DInstance.CameraPosition = menuItem.CameraOptions?.Position ?? InitialCameraPosition;
            Root3DInstance.CameraRotation = menuItem.CameraOptions?.Rotation ?? InitialCameraRotation;
        }
    }
}
