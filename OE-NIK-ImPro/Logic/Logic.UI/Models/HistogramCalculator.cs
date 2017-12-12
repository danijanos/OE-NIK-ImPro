using System.Drawing;
using System.Drawing.Imaging;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    public class HistogramCalculator
    {
        /// <summary>
        /// filed which stores [Luminosity, Red, Green, Blue]
        /// </summary>
        private int[][] _rgbColor;

        /// <summary>
        /// Dimensions
        /// </summary>
        private int _width;
        private int _height;
        private readonly bool _imagGrayscale;

        private BitmapData srcData;

        public HistogramCalculator(Bitmap sourceImage)
        {
            _width = sourceImage.Width;
            _height = sourceImage.Height;
            _rgbColor = new[] { new int[256], new int[256], new int[256], new int[256] };
            _imagGrayscale = (sourceImage.PixelFormat == PixelFormat.Format8bppIndexed);
            
            // lock bitmap data
            LockBitmapData(sourceImage);    

        }

        private void LockBitmapData(Bitmap sourceImage)
        {
            srcData = sourceImage.LockBits(
                new Rectangle(0, 0, _width, _height),
                ImageLockMode.ReadOnly,
                (_imagGrayscale ? PixelFormat.Format8bppIndexed : PixelFormat.Format24bppRgb)
                );
        }
    }
}
