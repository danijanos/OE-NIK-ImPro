using System.Diagnostics;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
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
            Messenger.Default.Register<HistogramPresenter>(
                this,
                msg =>
                {
                    Debug.WriteLine(msg.TestText);
                }
                );
        }
    }
}
