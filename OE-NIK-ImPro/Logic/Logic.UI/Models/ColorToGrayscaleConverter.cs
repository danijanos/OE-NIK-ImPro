using System;
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
            sourceImage.UnlockBits(SourceImageInBmData);
        }

        /// <summary>
        /// Converts the given image to grayscale
        /// </summary>
        private void ConvertImageToGrayscale()
        {
            if (IsImageGrayscale)
            {
                // Scan for the first line
                IntPtr ptr = SourceImageInBmData.Scan0;

                // Declare an array in which RGB values will be stored
                int size = Math.Abs(SourceImageInBmData.Stride) * ImageHeight;
                byte[] rgbValues = new byte[size];
            }
        }
    }
}
