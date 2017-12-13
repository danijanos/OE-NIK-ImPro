using System.Drawing;

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
        }

        /// <summary>
        /// Gets the width of the source image
        /// </summary>
        public int ImageWidth { get; private set; }

        /// <summary>
        /// Gets the heigth of the source image
        /// </summary>
        public int ImageHeight { get; private set; }
    }
}
