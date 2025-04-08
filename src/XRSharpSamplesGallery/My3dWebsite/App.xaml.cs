using System.Windows;
using System.Windows.Controls;

namespace My3dWebsite
{
    public sealed partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage();
            Window.Current.Content = mainPage;
        }
    }
}
