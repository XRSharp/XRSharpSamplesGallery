using XRSharp;
using XRSharp.AFrame.Components;
using XRSharpSamplesGallery.Menu;

namespace XRSharpSamplesGallery.Other
{
    public class CameraAnimation
    {
        private const string CameraPath = "object3D.el.sceneEl.camera";
        private const AnimationEasing Easing = AnimationEasing.easeInOutCubic;
        private const int DurationMs = 1000;
        private Point3D _cameraPosition = new CameraOptions().Position;

        private readonly Animation _animateCameraPositionX = new() { Property = $"{CameraPath}.position.x", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraPositionY = new() { Property = $"{CameraPath}.position.y", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraPositionZ = new() { Property = $"{CameraPath}.position.z", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationX = new() { Property = $"{CameraPath}.rotation.x", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationY = new() { Property = $"{CameraPath}.rotation.y", Enabled = false, Easing = Easing, DurationMs = DurationMs };
        private readonly Animation _animateCameraRotationZ = new() { Property = $"{CameraPath}.rotation.z", Enabled = false, Easing = Easing, DurationMs = DurationMs };

        public CameraAnimation(Root3D root3D)
        {
            root3D.CameraPosition = _cameraPosition;

            var components = root3D.Content.Components;
            components.Add(_animateCameraPositionX);
            components.Add(_animateCameraPositionY);
            components.Add(_animateCameraPositionZ);
            components.Add(_animateCameraRotationX);
            components.Add(_animateCameraRotationY);
            components.Add(_animateCameraRotationZ);
        }

        internal void Animate(CameraOptions cameraOptions)
        {
            var position = cameraOptions.Position;
            var rotation = cameraOptions.Rotation;

            _animateCameraPositionX.To = $"{(position.X - _cameraPosition.X).ToInvariantString()}";
            _animateCameraPositionY.To = $"{(position.Y - _cameraPosition.Y).ToInvariantString()}";
            _animateCameraPositionZ.To = $"{(position.Z - _cameraPosition.Z).ToInvariantString()}";
            _animateCameraRotationX.To = $"{rotation.X.ToRadiansInvariantString()}";
            _animateCameraRotationY.To = $"{rotation.Y.ToRadiansInvariantString()}";
            _animateCameraRotationZ.To = $"{rotation.Z.ToRadiansInvariantString()}";

            _animateCameraPositionX.Play();
            _animateCameraPositionY.Play();
            _animateCameraPositionZ.Play();
            _animateCameraRotationX.Play();
            _animateCameraRotationY.Play();
            _animateCameraRotationZ.Play();
            _cameraPosition = position;
        }
    }
}
