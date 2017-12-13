using System.Drawing;
using System.Drawing.Imaging;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    /// <summary>
    /// Base for image processer classes
    /// </summary>
    public abstract class BaseImageProcesser
    {
        /// <summary>
        /// Initilaize a new instance of a <see cref="BaseImageProcesser"/> class
        /// </summary>
        /// <param name="sourceImage">The source of the image</param>
        protected BaseImageProcesser(Bitmap sourceImage)
        {
            ImageWidth = sourceImage.Width;
            ImageHeight = sourceImage.Height;
            IsImageGrayscale = (sourceImage.PixelFormat == PixelFormat.Format8bppIndexed);

            // lock bitmap data
            LockSourceImageBits(sourceImage);
            // Todo: call the function that consumes and process the image
            sourceImage.UnlockBits(SourceImageToBmData);
        }

        /// <summary>
        /// Gets the width of the source image
        /// </summary>
        public int ImageWidth { get; internal set; }

        /// <summary>
        /// Gets the heigth of the source image
        /// </summary>
        public int ImageHeight { get; internal set; }

        /// <summary>
        /// Determines that the source image is weather grayscale or not
        /// </summary>
        public bool IsImageGrayscale { get; internal set; }

        /// <summary>
        /// Stores the source image as BitmapData
        /// </summary>
        public BitmapData SourceImageToBmData { get; internal set; }

        /// <summary>
        /// Locks the bits of the given bitmap image and add it to <see cref="SourceImageToBmData"/> property for further processing
        /// </summary>
        /// <param name="sourceImage">The source of the image as a Bitmap</param>
        internal void LockSourceImageBits(Bitmap sourceImage)
        {
            SourceImageToBmData = sourceImage.LockBits(
                new Rectangle(0, 0, ImageWidth, ImageHeight),
                ImageLockMode.ReadOnly,
                (IsImageGrayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb)
            );
        }

        // TODO: perhaps need to create a ImageLockMode.ReadWrite version?
    }
}
