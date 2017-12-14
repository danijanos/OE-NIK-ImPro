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

        }
    }
}
