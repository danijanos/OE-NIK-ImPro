using System.Drawing;

namespace OE.NIK.ImPro.Logic.UI.Models
{
    public class HistogramCalculator
    {
        /// <summary>
        /// filed which stores [Luminosity, Red, Green, Blue]
        /// </summary>
        private int[][] _rgbColor;

        public HistogramCalculator(Bitmap sourceImage)
        {
            _rgbColor = new[] { new int[256], new int[256], new int[256], new int[256] };
        }
    }
}
