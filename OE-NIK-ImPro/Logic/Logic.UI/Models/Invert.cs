using System.Drawing;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Class which inverts color images
    /// </summary>
    internal sealed class Invert : BaseImageProcesser
    {
        /// <summary>
        /// Initilaize a new instance of the <see cref="Invert"/> class
        /// </summary>
        /// <param name="sourceImage">The source of the image</param>
        public Invert(Bitmap sourceImage) : base(sourceImage)
        {
            InvertImage();
            sourceImage.UnlockBits(BitmapDataFromSource);
        }

        /// <summary>
        /// Imverts a given image
        /// </summary>
        private void InvertImage()
        {
            unsafe
            {
                byte* p = (byte*)(void*)Scan0IntPtr;
                int nOffset = ImageStride - ImageWidth * 3;
                int nWidth = ImageWidth * 3;
                for (int y = 0; y < ImageHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        p[0] = (byte)(255 - p[0]);
                        ++p;
                    }
                    p += nOffset;
                }
            }
        }
    }
}
