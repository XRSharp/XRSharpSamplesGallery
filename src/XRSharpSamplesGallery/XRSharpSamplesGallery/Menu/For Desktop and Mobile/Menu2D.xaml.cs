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

namespace XRSharpSamplesGallery.Menu
{
    public partial class Menu2D : UserControl
    {
        public Menu2D()
        {
            this.InitializeComponent();
        }

        public event SelectionChangedEventHandler SelectionChanged;

        private void MainMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectionChanged?.Invoke(this, e);
        }

        public Type SelectedPage
        {
            get
            {
                //return (MenuListBox.SelectedItem as MenuItem)?.PageToNavigateTo;
                return MenuListBox.SelectedValue as Type;
            }
            set
            {
                MenuListBox.SelectedValue = value;
                //var menuItems = this.Resources["MenuItems"] as MenuItems;
                //MenuListBox.SelectedItem = menuItems.Single(x => x.PageToNavigateTo == value);
            }
        }
    }
}
