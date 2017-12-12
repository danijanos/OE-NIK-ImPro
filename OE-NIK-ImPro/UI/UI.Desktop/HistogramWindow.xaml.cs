using LiveCharts;

namespace OE.NIK.ImPro.UI.Desktop
{
    /// <summary>
    /// Interaction logic for HistogramWindow.xaml
    /// </summary>
    public partial class HistogramWindow
    {
        public HistogramWindow()
        {
            InitializeComponent();
            DataContext = this;            
        }

        public SeriesCollection SeriesCollection { get; set; }             
    }
}
