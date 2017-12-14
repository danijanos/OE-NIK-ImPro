using System;
using System.Drawing;
using System.Runtime.InteropServices;

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
            if (IsImageGrayscale == false) // Color image
            {
                // Declare an array in which RGB values will be stored
                int size = Math.Abs(ImageStride) * ImageHeight;
                byte[] rgbValues = new byte[size];

                // Copy RGB values to the array
                Marshal.Copy(Scan0IntPtr, rgbValues, 0, size);

                for (int i = 0; i < size; i += 3)
                {
                    // Set all RGB values to gray where all RGB values was stored
                    byte gray = (byte)(rgbValues[i] * 0.21 + rgbValues[i + 1] * 0.71 + rgbValues[i + 2] * 0.071);
                    rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = gray;
                }

                // Copy changed RGB values back to bitmap
                Marshal.Copy(rgbValues, 0, Scan0IntPtr, size);                
            }
        }
    }
}
