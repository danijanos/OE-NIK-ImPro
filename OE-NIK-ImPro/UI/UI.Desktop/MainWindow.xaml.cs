using System.Windows;
using OE.NIK.ImPro.Logic.UI;

namespace OE.NIK.ImPro.UI.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            // Application.Current.Shutdown();
            ViewModelLocator.Cleanup();            
        }
    }
}
