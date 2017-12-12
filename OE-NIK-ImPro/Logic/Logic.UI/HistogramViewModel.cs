using GalaSoft.MvvmLight;

namespace OE.NIK.ImPro.Logic.UI
{
    /// <inheritdoc />
    /// <summary>
    /// View model for HistogramWindow
    /// </summary>
    public class HistogramViewModel : ViewModelBase
    {
        public int[][] HistogramValues { get; set; }
    }
}
