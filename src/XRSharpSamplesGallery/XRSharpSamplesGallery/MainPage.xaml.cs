using OpenSilver;
using System;
using System.Windows;
using System.Windows.Controls;
using XRSharp.Components;
using XRSharp.Core;
using XRSharp.Shadows;
using XRSharpSamplesGallery.Menu;
using XRSharpSamplesGallery.Other;

namespace XRSharpSamplesGallery
{
    public partial class MainPage : Page
    {
        private readonly CameraAnimation _cameraAnimation;
        private readonly MenuViewModel _menuViewModel;
        private bool _inXRMode;

        public MainPage()
        {
            InitializeComponent();

            LodingText.Visibility = Visibility.Visible;

            _menuViewModel = new MenuViewModel();
            _menuViewModel.SelectionChanged += OnSelectionChanged;
            DataContext = _menuViewModel;

            _cameraAnimation = new CameraAnimation(Root3DInstance);

            EnvironmentInstance.RoomModel.ModelLoaded += (_, __) => ProgressiveShadows.Update(Root3DInstance);
            _cameraAnimation.AnimationCompleted += OnAnimationCompleted;
        }

        private void OnSelectionChanged(object sender, Menu.MenuItem menuItem)
        {
            if(_inXRMode)
                EnvironmentInstance.Visibility = menuItem.IsRoomVisible && Root3DInstance.IsInVRMode ? Visibility.Visible: Visibility.Collapsed;
            else
                EnvironmentInstance.Visibility = menuItem.IsRoomVisible ? Visibility.Visible: Visibility.Collapsed;

            EnvironmentInstance.IsHitTestVisible = EnvironmentInstance.Visibility == Visibility.Collapsed? false : true;
            if (menuItem.IsRoomVisible)
            {
                EnvironmentInstance.Visibility = Visibility.Visible;
                Interop.ExecuteJavaScriptVoid($"{EnvironmentInstance.JsElement}.firstChild.setAttribute('interactable', '')");
            }
            else
            {
                EnvironmentInstance.Visibility = Visibility.Collapsed;
                Interop.ExecuteJavaScriptVoid($"{EnvironmentInstance.JsElement}.firstChild.removeAttribute('interactable')");
            }

            OrbitControls.SetEnabled(Root3DInstance, menuItem.IsOrbitControlsEnabled);

            // Hide the panel that shows the Source Code when navigating:
            ViewSourcePane.Collapse();

            // Hide the menu when navigating if we are on mobile:
            MenuResponsivePane.CollapseIfMobile();

            _cameraAnimation.Animate(menuItem.CameraOptions);

            if (!_inXRMode)
            {
                ProgressiveShadows.Clear(Root3DInstance);

                var currentShadowType = Renderer.GetShadowType(Root3DInstance);
                if (currentShadowType == ShadowType.Progressive && menuItem.ShadowType == ShadowType.PCFSoft)
                {
                    EnableSoftShadows();
                }
                else if (currentShadowType == ShadowType.PCFSoft && menuItem.ShadowType == ShadowType.Progressive)
                {
                    EnableProgressiveShadows();
                }
            }
        }

        private void OnEnterXR(object sender, EventArgs e)
        {
            _inXRMode = true;
            Menu3DInstance.Visibility = Visibility.Visible;
            EnableSoftShadows();
        }

        private void OnExitXR(object sender, EventArgs e)
        {
            _inXRMode = false;
            Menu3DInstance.Visibility = Visibility.Collapsed;
            EnableProgressiveShadows();
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

        private void EnableSoftShadows()
        {
            MainDirectionalLight.CastShadows = true;
            Renderer.SetShadowType(Root3DInstance, ShadowType.PCFSoft);
            _cameraAnimation.AnimationCompleted -= OnAnimationCompleted;
        }

        private void EnableProgressiveShadows()
        {
            MainDirectionalLight.CastShadows = false;
            Renderer.SetShadowType(Root3DInstance, ShadowType.Progressive);
            ProgressiveShadows.Update(Root3DInstance);
            _cameraAnimation.AnimationCompleted += OnAnimationCompleted;
        }

        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            ProgressiveShadows.Update(Root3DInstance);
        }
    }
}
