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
        private bool _imagGrayscale;

        public HistogramCalculator(Bitmap sourceImage)
        {
            _width = sourceImage.Width;
            _height = sourceImage.Height;
            _rgbColor = new[] { new int[256], new int[256], new int[256], new int[256] };
            _imagGrayscale = (sourceImage.PixelFormat == PixelFormat.Format8bppIndexed);
        }
    }
}
