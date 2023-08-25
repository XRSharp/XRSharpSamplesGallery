using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XRSharpSamplesGallery.Samples;

namespace XRSharpSamplesGallery.Menu
{
    internal class MenuItems
    {
        public static List<MenuItemViewModel> Items;
        static MenuItems()
        {
            Items = new()
            {
                new(){ Title = "Calculator", PageToNavigateTo = typeof(Calculator3D) },
                new(){ Title = "Charts", PageToNavigateTo = typeof(Calculator3D) },
            };
        }
    }
}
