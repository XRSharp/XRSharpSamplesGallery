using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using XRSharpSamplesGallery.Samples;

namespace XRSharpSamplesGallery
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            this.Loaded += MainPage_Loaded;
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
            MainContainer.Content = null;
            MainContainer.Content = content;

            // Hide the menu if we are in mobile and the menu is on top of everything:
            ResponsivePaneInstance.CollapseIfMobile();
        }
    }
}
