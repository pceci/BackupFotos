using System;
using System.IO;

namespace BackupFotos
{
    class cClasesFotos
    {
        public string title { get; set; }
        public cGooglePhotosOrigin googlePhotosOrigin { get; set; }

    }
    class cGooglePhotosOrigin
    {
        public cMobileUpload mobileUpload { get; set; }
        // public string deviceType { get; set; }
    }
    class cMobileUpload
    {
        public string deviceType { get; set; }
    }
}