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
                    new ViewSourceFileInfo() { TabHeader = "Welcome.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Welcome/Welcome.xaml" },
                    new ViewSourceFileInfo() { TabHeader = "Welcome.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Welcome/Welcome.xaml.cs" }
                }
            });
            this.Add(new()
            {
                Title = "Calculator 3D",
                PageToNavigateTo = typeof(Calculator3D),
                ThumbnailUri = "/Menu/Thumbnails/Calculator3D.jpg",
                CameraOptions = new CameraOptions
                {
                    Position = new Point3D(-0.147, 0.91, -0.51),
                    Rotation = new Point3D(-18.435, -3.619, -1.205),
                    TargetPoint = new Point3D(-0.135, 0.85, -0.69),
                },
                ViewSourceFilesLocation = new[]
                {
                    new ViewSourceFileInfo() { TabHeader = "Calculator3D.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Calculator3D/Calculator3D.xaml" },
                    new ViewSourceFileInfo() { TabHeader = "Calculator3D.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Calculator3D/Calculator3D.xaml.cs" }
                }
            });
            this.Add(new()
            {
                Title = "Primitives",
                PageToNavigateTo = typeof(Primitives),
                ThumbnailUri = "/Menu/Thumbnails/Primitives.jpg",
                CameraOptions = new CameraOptions
                {
                    Position = new Point3D(0, 1, 0),
                    Rotation = new Point3D(-9.463, 0, 0),
                    TargetPoint = new Point3D(0, 0.9, -0.6),
                },
                ViewSourceFilesLocation = new[]
                {
                    new ViewSourceFileInfo() { TabHeader = "Primitives.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Primitives/Primitives.xaml" },
                    new ViewSourceFileInfo() { TabHeader = "Primitives.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Primitives/Primitives.xaml.cs" }
                }
            });
            this.Add(new()
            {
                Title = "Controls",
                PageToNavigateTo = typeof(Controls),
                ThumbnailUri = "/Menu/Thumbnails/Controls.jpg",
                CameraOptions = new CameraOptions
                {
                    Position = new Point3D(0, 1, 0),
                    Rotation = new Point3D(-9.464, 0, 0),
                    TargetPoint = new Point3D(0, 0.9, -0.6),
                },
                ViewSourceFilesLocation = new[]
                {
                    new ViewSourceFileInfo() { TabHeader = "Controls.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Controls/Controls.xaml" },
                    new ViewSourceFileInfo() { TabHeader = "Controls.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Controls/Controls.xaml.cs" }
                }
            });
            this.Add(new()
            {
                Title = "ItemsControl3D",
                PageToNavigateTo = typeof(ItemsControl3D),
                ThumbnailUri = "/Menu/Thumbnails/ItemsControl3D.jpg",
                CameraOptions = new CameraOptions
                {
                    Position = new Point3D(0, 1, 0),
                    Rotation = new Point3D(-9.464, 0, 0),
                    TargetPoint = new Point3D(0, 0.9, -0.6),
                },
                //ViewSourceFilesLocation = new[]
                //{
                //    new ViewSourceFileInfo() { TabHeader = "Controls.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Controls/Controls.xaml" },
                //    new ViewSourceFileInfo() { TabHeader = "Controls.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Controls/Controls.xaml.cs" }
                //}
            });
            //this.Add(new()
            //{
            //    Title = "MVVM",
            //    PageToNavigateTo = typeof(MVVM),
            //    ThumbnailUri = "/Menu/Thumbnails/UnderConstruction.jpg",
            //    ViewSourceFilesLocation = new[]
            //    {
            //        new ViewSourceFileInfo() { TabHeader = "MVVM.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/MVVM/MVVM.xaml" },
            //        new ViewSourceFileInfo() { TabHeader = "MVVM.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/MVVM/MVVM.xaml.cs" }
            //    }
            //});
            //this.Add(new()
            //{
            //    Title = "Charts 3D",
            //    PageToNavigateTo = typeof(Charts3D),
            //    ThumbnailUri = "/Menu/Thumbnails/UnderConstruction.jpg",
            //    ViewSourceFilesLocation = new[]
            //    {
            //        new ViewSourceFileInfo() { TabHeader = "Calculator3D.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Charts3D/Charts3D.xaml" },
            //        new ViewSourceFileInfo() { TabHeader = "Calculator3D.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Charts3D/Charts3D.xaml.cs" }
            //    }
            //});
            //this.Add(new()
            //{
            //    Title = "Maps 3D",
            //    PageToNavigateTo = typeof(Maps3D),
            //    ThumbnailUri = "/Menu/Thumbnails/UnderConstruction.jpg",
            //    ViewSourceFilesLocation = new[]
            //    {
            //        new ViewSourceFileInfo() { TabHeader = "Maps3D.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Maps3D/Maps3D.xaml" },
            //        new ViewSourceFileInfo() { TabHeader = "Maps3D.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Maps3D/Maps3D.xaml.cs" }
            //    }
            //});
            //this.Add(new()
            //{
            //    Title = "Physics",
            //    PageToNavigateTo = typeof(Physics),
            //    ThumbnailUri = "/Menu/Thumbnails/UnderConstruction.jpg",
            //    ViewSourceFilesLocation = new[]
            //    {
            //        new ViewSourceFileInfo() { TabHeader = "Physics.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Physics/Physics.xaml" },
            //        new ViewSourceFileInfo() { TabHeader = "CalcuPhysicslator3D.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/Physics/Physics.xaml.cs" }
            //    }
            //});
            //this.Add(new()
            //{
            //    Title = "Multi-User",
            //    PageToNavigateTo = typeof(MultiUser),
            //    ThumbnailUri = "/Menu/Thumbnails/UnderConstruction.jpg",
            //    ViewSourceFilesLocation = new[]
            //    {
            //        new ViewSourceFileInfo() { TabHeader = "MultiUser.xaml", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/MultiUser/MultiUser.xaml" },
            //        new ViewSourceFileInfo() { TabHeader = "MultiUser.xaml.cs", FilePathOnGitHub = "github/XRSharp/XRSharpSamplesGallery/blob/main/src/XRSharpSamplesGallery/XRSharpSamplesGallery/Samples/MultiUser/MultiUser.xaml.cs" }
            //    }
            //});
        }
    }
}
