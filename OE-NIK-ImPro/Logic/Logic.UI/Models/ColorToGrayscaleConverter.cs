using System.Drawing;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Class which converts color images to grayscale
    /// </summary>
    public sealed class ColorToGrayscaleConverter : BaseImageProcesser
    {
        /// <summary>
        /// Initilaize a new instance of the <see cref="ColorToGrayscaleConverter"/> class
        /// </summary>
        /// <param name="sourceImage">The source of the image</param>
        public ColorToGrayscaleConverter(Bitmap sourceImage) : base(sourceImage)
        {
            ConvertImageToGrayscale();
            sourceImage.UnlockBits(SourceImageToBmData);
        }

        private void ConvertImageToGrayscale()
        {
            throw new System.NotImplementedException();
        }
    }
}
