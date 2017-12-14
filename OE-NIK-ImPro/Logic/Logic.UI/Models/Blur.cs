using System.Drawing;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <summary>
    /// Class which applies blurring operation in the image
    /// </summary>
    internal sealed class Blur : Convolution
    {
        public Blur(Bitmap sourceImage) : base(sourceImage)
        {
            BlurImage();
            sourceImage.UnlockBits(SourceImageInBmData);
        }

        private void BlurImage()
        {
            SetConvolutionMatrixToGaussian();
            base.ConvolutionOverTheImage(ConvolutionMatrix);
        }

        private void SetConvolutionMatrixToGaussian()
        {            
            ConvolutionMatrix.SetAllValues(1);
            ConvolutionMatrix.Pixel = 4;
            ConvolutionMatrix.TopMid = ConvolutionMatrix.MidRight = ConvolutionMatrix.BottomMid = ConvolutionMatrix.MidLeft = 2;
            ConvolutionMatrix.Factor = 16;
        }
    }
}
