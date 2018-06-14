using System;
using System.Collections.Generic;
using System.Text;

namespace Phantom.Models
{
    public class CustomFileInfo
    {
        public string Filename { get; set; }

        public string Description { get; set; }

        public bool Available { get; set; }

        public object OriginalData { get; set; }
    }
}
