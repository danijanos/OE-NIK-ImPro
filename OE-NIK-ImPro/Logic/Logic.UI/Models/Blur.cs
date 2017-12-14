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
        }

        private void BlurImage()
        {
            SetMatrix();
        }

        private void SetMatrix()
        {
            throw new System.NotImplementedException();
        }
    }
}
