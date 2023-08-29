using XRSharp;

namespace XRSharpSamplesGallery.Menu
{
    internal class CameraOptions
    {
        public Point3D Position { get; set; } = new Point3D(0, 1.2, 0);

        public Point3D Rotation { get; set; } = new Point3D(-10, 0, 0);
    }
}
