namespace OE.NIK.ImPro.Logic.UI
{
    public class HistogramPresenter
    {
        public HistogramPresenter(string filePath)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; }
    }
}