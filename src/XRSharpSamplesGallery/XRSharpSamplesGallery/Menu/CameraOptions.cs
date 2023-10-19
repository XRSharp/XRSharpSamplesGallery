using XRSharp;

namespace XRSharpSamplesGallery.Menu
{
    internal class CameraOptions
    {
        public Point3D Position { get; set; } = new Point3D(0, 1, 0);

        public Point3D Rotation { get; set; } = new Point3D(-9.462, 0, 0);

        public Point3D TargetPoint { get; set; } = new Point3D(0, 0.9, -0.6);
    }
}
