using System.Collections.Generic;
using System.Drawing;
using OE.NIK.ImPro.Logic.UI.Models;

namespace OE.NIK.ImPro.Logic.UI
{
    public class HistogramPresenter
    {
        public HistogramPresenter(Bitmap sourceBitmap)
        {
            var histogramCalculator = new HistogramCalculator(sourceBitmap);
            ImageHistogramValues = histogramCalculator.LrgbBucket;
            LuminosityFromSourceImage = GetLuminosityFromImageHistogramValues();
        }

        private IEnumerable<int> GetLuminosityFromImageHistogramValues()
        {
            List<int> luminosityList = new List<int>();
            foreach (int i in ImageHistogramValues[0])
            {
                luminosityList.Add(i);
            }
            return luminosityList;
        }

        public int[][] ImageHistogramValues { get; set; }

        public IEnumerable<int> LuminosityFromSourceImage { get; set; }
    }
}