using System;
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

            // lock bitmap data for processing
            LockSourceImageBits(sourceImage);
            ImageStride = SourceImageInBmData.Stride;
            Scan0IntPtr = SourceImageInBmData.Scan0;

            // Todo: call the function that consumes and process the image
            // TODO: every child instance should unlock bits => sourceImage.UnlockBits(SourceImageInBmData); !!!
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
        public BitmapData SourceImageInBmData { get; internal set; }

        /// <summary>
        /// Gets the stride(scan) width of the Bitmap object.        
        /// </summary>
        public int ImageStride { get; private set; }

        /// <summary>
        /// Gets the address of the first pixel data in the bitmap
        /// </summary>
        public IntPtr Scan0IntPtr { get; private set; }

        /// <summary>
        /// Locks the bits of the given bitmap image and add it to <see cref="SourceImageInBmData"/> property for further processing
        /// </summary>
        /// <param name="sourceImage">The source of the image as a Bitmap</param>
        internal void LockSourceImageBits(Bitmap sourceImage)
        {
            SourceImageInBmData = sourceImage.LockBits(
                new Rectangle(0, 0, ImageWidth, ImageHeight),
                ImageLockMode.ReadWrite,
                (IsImageGrayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb)
            );
        }

        // TODO: perhaps need to create a ImageLockMode.Read version?
    }
}
