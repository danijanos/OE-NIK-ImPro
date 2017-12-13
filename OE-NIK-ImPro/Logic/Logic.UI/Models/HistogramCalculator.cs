using System.Drawing;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <inheritdoc />
    /// <summary>
    /// Class that calculates histogram values from an image
    /// </summary>
    public sealed class HistogramCalculator : BaseImageProcesser
    {
        /// <summary>
        /// Initialize a new instance of the <see cref="HistogramCalculator"/> class
        /// </summary>
        /// <param name="sourceImage">The source of the image</param>
        public HistogramCalculator(Bitmap sourceImage) : base(sourceImage)
        {
            FillLrgbBucket();
            sourceImage.UnlockBits(SourceImageToBmData);
        }

        /// <summary>
        /// A bucket which stores [Luminosity, Red, Green, Blue] values
        /// </summary>
        public int[][] LrgbBucket { get; private set; }

        /// <summary>
        /// An unsafe method to calculate luminosity, red, green and blue values from the image
        /// </summary>
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
