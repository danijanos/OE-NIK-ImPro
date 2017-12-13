using System.Drawing;
using System.Drawing.Imaging;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <summary>
    /// Class that calculates histogram values from an image
    /// </summary>
    public sealed class HistogramCalculator : BaseImageProcesser
    {
        /// <summary>
        /// A bucket which stores [Luminosity, Red, Green, Blue] values
        /// </summary>
        public int[][] LrgbBucket { get; private set; }

        /// <summary>
        /// Gets the width of the source image
        /// </summary>
        public int ImageWidth { get; private set; }

        /// <summary>
        /// Gets the heigth of the source image
        /// </summary>
        public int ImageHeight { get; private set; }

        /// <summary>
        /// Determines that the source image is weather grayscale or not
        /// </summary>
        public bool IsImageGrayscale { get; private set; }

        /// <summary>
        /// Stores the source image as BitmapData
        /// </summary>
        public BitmapData SourceImageToBmData { get; private set; }

        public HistogramCalculator(Bitmap sourceImage)
        {
            ImageWidth = sourceImage.Width;
            ImageHeight = sourceImage.Height;
            IsImageGrayscale = (sourceImage.PixelFormat == PixelFormat.Format8bppIndexed);

            // lock bitmap data
            LockSourceImageBits(sourceImage);
            FillLrgbBucket();
            sourceImage.UnlockBits(SourceImageToBmData);
        }

        private void LockSourceImageBits(Bitmap sourceImage)
        {
            SourceImageToBmData = sourceImage.LockBits(
                new Rectangle(0, 0, ImageWidth, ImageHeight),
                ImageLockMode.ReadOnly,
                (IsImageGrayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb)
                );
        }

        private unsafe void FillLrgbBucket()
        {
            // Initialize the bucket
            LrgbBucket = new[] { new int[256], new int[256], new int[256], new int[256] };

            // Initialize pointers
            byte* pointer = (byte*)SourceImageToBmData.Scan0.ToPointer();
            int pointerIncrementation = IsImageGrayscale ? 1 : 3;
            int remain = SourceImageToBmData.Stride - ImageWidth * pointerIncrementation;

            // walk through the image pixel by pixel
            for (int i = 0; i < ImageHeight; ++i, pointer += remain)
                for (int j = 0; j < ImageWidth; j++, pointer += pointerIncrementation)
                {
                    if (IsImageGrayscale == false) // Color image
                    {
                        // Luminosity
                        ++LrgbBucket[0][(int)(0.114 * pointer[0] + 0.587 * pointer[1] + 0.299 * pointer[2])];
                        // Red
                        ++LrgbBucket[1][pointer[2]];
                        // Green
                        ++LrgbBucket[2][pointer[1]];
                        // Blue
                        ++LrgbBucket[3][pointer[0]];
                    }
                    else ++LrgbBucket[0][pointer[0]]; // Grayscale image (just luminosity)
                }
        }
    }
}
