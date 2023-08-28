using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRSharpSamplesGallery.Samples;

namespace XRSharpSamplesGallery.Menu
{
    internal class MenuItems : List<MenuItem>
    {
        public MenuItems()
        {
            this.Add(new() { Title = "Welcome", PageToNavigateTo = typeof(Welcome), ThumbnailUri = "/thumbnails/Welcome.jpg" });
            this.Add(new() { Title = "Calculator 3D", PageToNavigateTo = typeof(Calculator3D), ThumbnailUri = "/thumbnails/Calculator3D.jpg" });
            //this.Add(new() { Title = "Charts 3D", PageToNavigateTo = typeof(Charts) });
        }
    }
}
