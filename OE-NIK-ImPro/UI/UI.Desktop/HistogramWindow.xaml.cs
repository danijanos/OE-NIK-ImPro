using LiveCharts;
using LiveCharts.Wpf;

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

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Histogram",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            Labels = new[] { "Maria", "Susan", "Charles", "Frida" };            

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }        
    }
}
