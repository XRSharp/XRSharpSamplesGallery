using System.Linq;
using XRSharp;
using XRSharp.CommunityToolkit.Networked;
using XRSharp.Controls;

namespace XRSharpSamplesGallery.Samples
{
    public partial class MultiUser : UserControl3D
    {
        public MultiUser()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!Root3D.Current.Components.OfType<NetworkedScene>().Any())
            {
                Root3D.Current.Components.Add((NetworkedScene)Resources["networked"]);
            }
        }
    }
}
