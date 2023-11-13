using System;
using XRSharp;
using XRSharp.Components;
using XRSharpSamplesGallery.Menu;

namespace XRSharpSamplesGallery.Other
{
    public class CameraAnimation
    {
        private const string CameraPath = "object3D.el.sceneEl.camera";
        private const AnimationEasing Easing = AnimationEasing.easeInOutCubic;
        private const int DurationMs = 1500;
        private readonly bool _orbitControlsEnabled;
        private readonly Root3D _root3D;

        private readonly Animation _animateCameraPositionX = new() { Property = $"{CameraPath}.position.x", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraPositionY = new() { Property = $"{CameraPath}.position.y", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraPositionZ = new() { Property = $"{CameraPath}.position.z", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationX = new() { Property = $"{CameraPath}.rotation.x", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationY = new() { Property = $"{CameraPath}.rotation.y", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationZ = new() { Property = $"{CameraPath}.rotation.z", Enabled = false, Easing = Easing, DurationMs = DurationMs };

        public event EventHandler AnimationCompleted;

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
            _orbitControlsEnabled = OrbitControls.GetEnabled(_root3D);
        }

        internal void Animate(CameraOptions cameraOptions)
        {
            if (_root3D.Content.JsElement == null)
                return;

            var position = cameraOptions.Position;
            var rotation = cameraOptions.Rotation;

            if (_orbitControlsEnabled)
            {
                OrbitControls.SetEnabled(_root3D, false);
                OrbitControls.SetTarget(_root3D, cameraOptions.TargetPoint);
            }
            else
            {
                DisableLookControls();
            }

            var state = Interop.ExecuteJavaScriptGetResult<string>($@"
var camera = {_root3D.Content.JsElement}.sceneEl.camera;
function round(num) {{ return Math.round((num + Number.EPSILON) * 1000) / 1000; }}
var p = camera.el.object3D.worldToLocal(new THREE.Vector3({position.X.ToInvariantString()}, {position.Y.ToInvariantString()}, {position.Z.ToInvariantString()}));
round(camera.position.x) + '|' + round(camera.position.y) + '|' + round(camera.position.z) + '|'
  + round(camera.rotation.x) + '|' + round(camera.rotation.y) + '|' + round(camera.rotation.z) + '|'
  + round(p.x) + '|' + round(p.y) + '|' + round(p.z);")
                .Split('|');

            _animateCameraPositionX.From = state[0];
            _animateCameraPositionY.From = state[1];
            _animateCameraPositionZ.From = state[2];
            _animateCameraRotationX.From = state[3];
            _animateCameraRotationY.From = state[4];
            _animateCameraRotationZ.From = state[5];

            _animateCameraPositionX.To = state[6];
            _animateCameraPositionY.To = state[7];
            _animateCameraPositionZ.To = state[8];
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
            AnimationCompleted?.Invoke(this, null);

            if (_orbitControlsEnabled)
            {
                OrbitControls.SetEnabled(_root3D, true);
            }
            else
            {
                EnableLookControls();
            }
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
