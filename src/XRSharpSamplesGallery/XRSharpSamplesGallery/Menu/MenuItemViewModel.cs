﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XRSharpSamplesGallery.Menu
{
    internal class MenuItemViewModel
    {
        public string Title { get; set; }

        public Type PageToNavigateTo { get; set; }
    }
}