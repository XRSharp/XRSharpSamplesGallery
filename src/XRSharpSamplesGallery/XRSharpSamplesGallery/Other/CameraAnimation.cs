using System;
using XRSharp;
using XRSharp.Components;
using XRSharpSamplesGallery.Menu;

namespace XRSharpSamplesGallery.Other
{
    public class CameraAnimation
    {
        private const string CameraPath = "object3D.el.sceneEl.camera.el.object3D";
        private const AnimationEasing Easing = AnimationEasing.easeInOutCubic;
        private const int DurationMs = 1500;
        private readonly Root3D _root3D;

        private readonly Animation _animateCameraPositionX = new() { Property = $"{CameraPath}.position.x", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraPositionY = new() { Property = $"{CameraPath}.position.y", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraPositionZ = new() { Property = $"{CameraPath}.position.z", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationX = new() { Property = $"{CameraPath}.rotation.x", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationY = new() { Property = $"{CameraPath}.rotation.y", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationZ = new() { Property = $"{CameraPath}.rotation.z", Enabled = false, Easing = Easing, DurationMs = DurationMs };

        public CameraAnimation(Root3D root3D)
        {
            _root3D = root3D;

            var components = root3D.Content.Components;
            components.Add(_animateCameraPositionX);
            components.Add(_animateCameraPositionY);
            components.Add(_animateCameraPositionZ);
            components.Add(_animateCameraRotationX);
            components.Add(_animateCameraRotationY);
            components.Add(_animateCameraRotationZ);

            _animateCameraPositionX.Completed += OnAnimationCompleted;
        }

        internal void Animate(CameraOptions cameraOptions)
        {
            if (_root3D.Content.JsElement == null)
                return;

            DisableLookControls();

            var position = cameraOptions.Position;
            var rotation = cameraOptions.Rotation;

            _animateCameraPositionX.To = $"{position.X.ToInvariantString()}";
            _animateCameraPositionY.To = $"{position.Y.ToInvariantString()}";
            _animateCameraPositionZ.To = $"{position.Z.ToInvariantString()}";
            _animateCameraRotationX.To = $"{rotation.X.ToRadiansInvariantString()}";
            _animateCameraRotationY.To = $"{rotation.Y.ToRadiansInvariantString()}";
            _animateCameraRotationZ.To = $"{rotation.Z.ToRadiansInvariantString()}";

            _animateCameraPositionX.Play();
            _animateCameraPositionY.Play();
            _animateCameraPositionZ.Play();
            _animateCameraRotationX.Play();
            _animateCameraRotationY.Play();
            _animateCameraRotationZ.Play();
        }

        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            EnableLookControls();
        }

        private void DisableLookControls()
        {
            Interop.ExecuteJavaScriptVoid($@"
var lookControls = {_root3D.Content.JsElement}.sceneEl.camera.el.components['look-controls'];
if (lookControls && lookControls.data.enabled) {{
  lookControls.magicWindowTrackingEnabled = false;
  lookControls.pause();
}}");
        }

        private void EnableLookControls()
        {
            Interop.ExecuteJavaScriptVoid($@"
var lookControls = {_root3D.Content.JsElement}.sceneEl.camera.el.components['look-controls'];
if (lookControls && lookControls.data.enabled) {{
  lookControls.setupMouseControls();
  lookControls.pitchObject.rotation.x = lookControls.el.object3D.rotation.x;
  lookControls.yawObject.rotation.y = lookControls.el.object3D.rotation.y;
  lookControls.play();
}}");
        }
    }
}
