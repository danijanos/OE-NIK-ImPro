using System.Drawing;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    internal class Convolution : BaseImageProcesser
    {
        public Convolution(Bitmap sourceImage) : base(sourceImage)
        {

        }


        public ConvolutionMatrix ConvolutionMatrix { get; internal set; }
    }
}
