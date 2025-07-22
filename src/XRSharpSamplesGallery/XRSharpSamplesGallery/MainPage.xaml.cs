using System;
using System.Windows;
using System.Windows.Controls;
using XRSharp;
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

            EnvironmentInstance.RoomModel.ModelLoaded += (_, __) => UpdateProgressiveShadows();
            _cameraAnimation.AnimationCompleted += OnAnimationCompleted;
        }

        private void OnSelectionChanged(object sender, Menu.MenuItem menuItem)
        {
            var isRoomVisible = !Root3DInstance.IsInARMode && menuItem.IsRoomVisible;
            EnvironmentInstance.Visibility = isRoomVisible ? Visibility.Visible : Visibility.Collapsed;

            Interop.ExecuteJavaScriptVoid($"{EnvironmentInstance.JsElement}.firstChild.setAttribute('visible', {isRoomVisible.ToLowerString()})");

            OrbitControls.SetEnabled(Root3DInstance, menuItem.IsOrbitControlsEnabled);

            // Hide the panel that shows the Source Code when navigating:
            ViewSourcePane.Collapse();

            // Hide the menu when navigating if we are on mobile:
            MenuResponsivePane.CollapseIfMobile();

            _cameraAnimation.Animate(menuItem.CameraOptions);

            if (!_inXRMode)
            {
                ProgressiveShadows.Clear(Root3DInstance);
                Renderer.SetEnableShadows(Root3DInstance, menuItem.EnableShadows);

                if (menuItem.EnableShadows)
                {
                    var currentShadowType = Renderer.GetShadowType(Root3DInstance);
                    if (currentShadowType != ShadowType.PCFSoft && menuItem.ShadowType == ShadowType.PCFSoft)
                    {
                        EnableSoftShadows();
                    }
                    else if (currentShadowType != ShadowType.Progressive && menuItem.ShadowType == ShadowType.Progressive)
                    {
                        MainDirectionalLight.CastShadows = false;
                    }
                }
            }
        }

        private void OnEnterXR(object sender, EventArgs e)
        {
            _inXRMode = true;
            Menu3DInstance.Visibility = Visibility.Visible;

            var currentShadowType = Renderer.GetShadowType(Root3DInstance);
            if (currentShadowType == ShadowType.Progressive && _menuViewModel.SelectedMenuItem.EnableShadows)
            {
                EnableSoftShadows();
            }
        }

        private void OnExitXR(object sender, EventArgs e)
        {
            _inXRMode = false;
            Menu3DInstance.Visibility = Visibility.Collapsed;
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
        }

        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            UpdateProgressiveShadows();
        }

        private void UpdateProgressiveShadows()
        {
            var menuItem = _menuViewModel.SelectedMenuItem;
            if (!_inXRMode && menuItem.EnableShadows && menuItem.ShadowType == ShadowType.Progressive)
            {
                Renderer.SetShadowType(Root3DInstance, ShadowType.Progressive);
                ProgressiveShadows.Update(Root3DInstance);
            }
        }
    }
}
