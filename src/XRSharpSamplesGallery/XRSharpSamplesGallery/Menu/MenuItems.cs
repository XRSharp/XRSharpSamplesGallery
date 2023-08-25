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
            this.Add(new() { Title = "Welcome", PageToNavigateTo = typeof(Welcome) });
            this.Add(new() { Title = "Calculator", PageToNavigateTo = typeof(Calculator3D) });
            this.Add(new() { Title = "Charts", PageToNavigateTo = typeof(Charts) });
        }
    }
}
