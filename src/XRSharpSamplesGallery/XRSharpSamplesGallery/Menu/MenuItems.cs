using System.Collections.Generic;
using XRSharp;
using XRSharpSamplesGallery.Samples;

namespace XRSharpSamplesGallery.Menu
{
    internal class MenuItems : List<MenuItem>
    {
        public MenuItems()
        {
            this.Add(new()
            {
                Title = "Welcome",
                PageToNavigateTo = typeof(Welcome),
                ThumbnailUri = "/thumbnails/Welcome.jpg"
            });
            this.Add(new()
            {
                Title = "Calculator 3D",
                PageToNavigateTo = typeof(Calculator3D),
                ThumbnailUri = "/thumbnails/Calculator3D.jpg",
                CameraOptions = new CameraOptions
                {
                    Position = new Point3D(-0.32, 0.92, -0.66),
                    Rotation = new Point3D(-21, -6, 0),
                }
            });
            //this.Add(new() { Title = "Charts 3D", PageToNavigateTo = typeof(Charts) });
        }
    }
}
