using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using XRSharp;
using XRSharp.Components;

namespace My3dWebsite
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            RootScrollViewer.Loaded += RootScrollViewer_Loaded;
        }

        private async void RootScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(2000);

            var scrollbar = GetScrollBar(RootScrollViewer, Orientation.Vertical);
            scrollbar.Scroll += Scrollbar_Scroll;
        }

        private void Scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            double scrollValue = e.NewValue;

            double x = (scrollValue / 400) * 0.4 - 0.2;
            double r = (scrollValue / 400) * 90 - 45;
            double a = -(1 - scrollValue / 400) * 40 - 25;

            Root.CameraPosition = new Point3D(x, 0.2, 0.3);
            Root.CameraRotation = new Point3D(a, r - 50, 0);
            //OrbitControls.SetTarget()
        }

        public static ScrollBar GetScrollBar(ScrollViewer scrollViewer, Orientation orientation)
        {
            // Ensure the ScrollViewer is loaded and has its template applied
            if (scrollViewer == null || scrollViewer.Template == null)
            {
                return null;
            }

            // Get the visual root of the ScrollViewer template
            var scrollViewerContent = VisualTreeHelper.GetChild(scrollViewer, 0) as FrameworkElement;

            if (scrollViewerContent == null)
            {
                return null;
            }

            // Find the ScrollBar inside the ScrollViewer template
            ScrollBar foundScrollBar = FindScrollBar(scrollViewerContent, orientation);
            return foundScrollBar;
        }

        private static ScrollBar FindScrollBar(DependencyObject root, Orientation orientation)
        {
            // Check if the current root is a ScrollBar
            ScrollBar scrollBar = root as ScrollBar;
            if (scrollBar != null && scrollBar.Orientation == orientation)
            {
                return scrollBar;
            }

            // Recursively check all children
            int childCount = VisualTreeHelper.GetChildrenCount(root);
            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(root, i);
                ScrollBar result = FindScrollBar(child, orientation);
                if (result != null)
                {
                    return result;
                }
            }

            // No ScrollBar found
            return null;
        }
    }


}
