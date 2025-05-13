// filepath: d:\userware\XRSharpSamplesGallery\src\XRSharpSamplesGallery\XRSharpSamplesGallery\Samples\Maps3D\Maps3D.xaml.cs
using System;
using System.Windows;
using XRSharp;
using XRSharp.Components;
using XRSharp.Controls;
using XRSharp.Controls.Extras;
using XRSharp.Core;

namespace XRSharpSamplesGallery.Samples
{
    public partial class Maps3D : UserControl3D
    {
        private Grid3D _infoPanel;
        private Root3D _root;
        
        public Maps3D()
        {
            InitializeComponent();
            
            // Find the root element to subscribe to XR events
            _root = Root3D.Current;
            
            // Get the info panel reference
            _infoPanel = this.FindName("infoPanel") as Grid3D;
            
            // Hide info panel by default (not in XR mode initially)
            if (_infoPanel != null)
            {
                _infoPanel.Visibility = Visibility.Collapsed;
            }
            
            // Subscribe to XR events
            if (_root != null)
            {
                _root.EnterXR += OnEnterXR;
                _root.ExitXR += OnExitXR;
            }
        }
        
        private void OnEnterXR(object sender, EventArgs e)
        {
            // Show the info panel when entering XR mode
            if (_infoPanel != null)
            {
                _infoPanel.Visibility = Visibility.Visible;
            }
        }
        
        private void OnExitXR(object sender, EventArgs e)
        {
            // Hide the info panel when exiting XR mode
            if (_infoPanel != null)
            {
                _infoPanel.Visibility = Visibility.Collapsed;
            }
        }
        
        private void OnUnloaded(object sender, EventArgs e)
        {
            // Clean up event handlers when control is unloaded
            if (_root != null)
            {
                _root.EnterXR -= OnEnterXR;
                _root.ExitXR -= OnExitXR;
            }
        }
    }
}
