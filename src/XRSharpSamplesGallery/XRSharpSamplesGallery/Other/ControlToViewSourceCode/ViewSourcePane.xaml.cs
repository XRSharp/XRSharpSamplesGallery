using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace XRSharpSamplesGallery.Other
{
    public partial class ViewSourcePane : UserControl
    {
        public ViewSourcePane()
        {
            this.InitializeComponent();
        }

        private void ButtonViewSource_Click(object sender, RoutedEventArgs e)
        {
            ViewSource(this.SourcePaths);
        }

        public void ViewSource(IEnumerable<ViewSourceFileInfo> sourcePaths)
        {
            if (sourcePaths != null && sourcePaths.Any())
            {
                var tabControl = new TabControl()
                {
                    Style = (Style)Application.Current.Resources["MaterialDesign_TabControl_Style"]
                };

                foreach (ViewSourceFileInfo viewSourceFileInfo in sourcePaths)
                {
                    var tabItem = new TabItem()
                    {
                        Header = viewSourceFileInfo.TabHeader,
                        Content = new ControlToViewSourceCode()
                        {
                            FilePathOnGitHub = viewSourceFileInfo.FilePathOnGitHub
                        },
                        Style = (Style)Application.Current.Resources["MaterialDesign_TabItem_Style"]
                    };

                    tabControl.Items.Add(tabItem);
                }

                ((TabItem)tabControl.Items[0]).IsSelected = true;

                DisplaySourceControl(tabControl);
            }
        }

        public void DisplaySourceControl(UIElement controlThatDisplaysTheSourceCode)
        {
            // Open the Source Code Pane, which is the place where the source code will be displayed:
            if (SourceCodePane.Visibility == Visibility.Collapsed)
            {
                ColumnForTheRestOfThePage.Width = new GridLength(0.3d, GridUnitType.Star);
                //ColumnForTheGridSplitter.Width = new GridLength(5d);
                ColumnForTheSourceCode.Width = new GridLength(0.7d, GridUnitType.Star);
                //GridSplitter1.ResizeDirection = GridSplitter.GridResizeDirection.Columns;
                //GridSplitter1.Visibility = Visibility.Visible;
                SourceCodePane.Visibility = Visibility.Visible;
                ButtonViewSource.Visibility = Visibility.Collapsed;
            }

            // Display the source code:
            PlaceWhereSourceCodeWillBeDisplayed.Child = controlThatDisplaysTheSourceCode;
        }

        public void Collapse()
        {
            // Close the Source Code Pane, which is the place where the source code is displayed:
            PlaceWhereSourceCodeWillBeDisplayed.Child = null;
            GridSplitter1.Visibility = Visibility.Collapsed;
            SourceCodePane.Visibility = Visibility.Collapsed;
            ColumnForTheRestOfThePage.Width = new GridLength(1d, GridUnitType.Star);
            ColumnForTheGridSplitter.Width = new GridLength(0d);
            ColumnForTheSourceCode.Width = new GridLength(0d);
            ButtonViewSource.Visibility =(Visibility)Visibility.Visible;
        }
        private void ButtonToCloseSourceCode_Click(object sender, RoutedEventArgs e)
        {
            Collapse();
        }

        public IEnumerable<ViewSourceFileInfo> SourcePaths
        {
            get { return (IEnumerable<ViewSourceFileInfo>)GetValue(SourcePathsProperty); }
            set { SetValue(SourcePathsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SourcePaths. This enables binding and more.
        public static readonly DependencyProperty SourcePathsProperty =
            DependencyProperty.Register("SourcePaths", typeof(IEnumerable<ViewSourceFileInfo>), typeof(ViewSourcePane), new PropertyMetadata(null));


    }
}
