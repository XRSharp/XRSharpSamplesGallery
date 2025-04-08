using System;
using System.Collections.Generic;
using XRSharp.Core;
using XRSharpSamplesGallery.Other;

namespace XRSharpSamplesGallery.Menu
{
    internal class MenuItem
    {
        public string Title { get; set; }

        public string ThumbnailUri { get; set; }

        public Type PageToNavigateTo { get; set; }

        public CameraOptions CameraOptions { get; set; } = new CameraOptions();

        public ShadowType ShadowType { get; set; } = ShadowType.Progressive;

        public IEnumerable<ViewSourceFileInfo> ViewSourceFilesLocation { get; set; }
    }
}
