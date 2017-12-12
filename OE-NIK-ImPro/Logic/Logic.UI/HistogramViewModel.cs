using GalaSoft.MvvmLight;

namespace OE.NIK.ImPro.Logic.UI
{
    /// <summary>
    /// View model for HistogramWindow
    /// </summary>
    public class HistogramViewModel : ViewModelBase
    {
        public HistogramViewModel()
        {
            if (IsInDesignMode)
            {
                
            }
        }

        public string MessageFromParent { get; set; }
    }
}
