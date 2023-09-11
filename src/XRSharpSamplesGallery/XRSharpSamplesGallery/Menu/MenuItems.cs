using System.Collections.Generic;
using XRSharp;
using XRSharpSamplesGallery.Other;
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
                ThumbnailUri = "/Menu/Thumbnails/Welcome.jpg",
                ViewSourceFilesLocation = new[]
                {
                    new ViewSourceFileInfo() { TabHeader = "Welcome.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Welcome.xaml" },
                    new ViewSourceFileInfo() { TabHeader = "Welcome.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Welcome.xaml.cs" }
                }
            });
            this.Add(new()
            {
                Title = "Calculator 3D",
                PageToNavigateTo = typeof(Calculator3D),
                ThumbnailUri = "/Menu/Thumbnails/Calculator3D.jpg",
                CameraOptions = new CameraOptions
                {
                    Position = new Point3D(-0.16, 0.91, -0.51),
                    Rotation = new Point3D(-21, -6, 0),
                },
                ViewSourceFilesLocation = new[]
                {
                    new ViewSourceFileInfo() { TabHeader = "Calculator3D.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Calculator3D.xaml" },
                    new ViewSourceFileInfo() { TabHeader = "Calculator3D.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Calculator3D.xaml.cs" }
                }
            });
            //this.Add(new() { Title = "Charts 3D", PageToNavigateTo = typeof(Charts) });
        }
    }
}
