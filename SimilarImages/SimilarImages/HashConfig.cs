using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimilarImages
{
    struct HashConfig
    {
        public int Precision { get; set; }

        public InterpolationMode InterpolationMode { get; set; }

        public HashEnum HashMethod { get; set; }

        public int Threshold { get; set; }
    }

    public enum HashEnum
    {
        Difference,
        Mean,
        Perceptual
    }
}
