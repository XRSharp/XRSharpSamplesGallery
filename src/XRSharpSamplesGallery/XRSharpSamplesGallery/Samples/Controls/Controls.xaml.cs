using System.Windows;
using XRSharp.Controls;
using XRSharp.Controls.Primitives;

namespace XRSharpSamplesGallery.Samples
{
    public partial class Controls : UserControl3D
    {
        private int _button3DClickTimes;
        private int _repeatButton3DClickTimes;

        public Controls()
        {
            InitializeComponent();
        }

        private void OnButton3DClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button3D button3D)
            {
                button3D.Content = "Click " + ++_button3DClickTimes;
            }
        }

        private void OnToggleButton3DClick(object sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton3D toggleButton)
            {
                toggleButton.Content = toggleButton.IsChecked switch
                {
                    true => "Checked",
                    false => "Unchecked",
                    null => "Indeterminate",
                };
            }
        }

        private void OnRepeatButton3DClick(object sender, RoutedEventArgs e)
        {
            if (sender is RepeatButton3D button3D)
            {
                button3D.Content = "Repeat " + ++_repeatButton3DClickTimes;
            }
        }
    }
}
