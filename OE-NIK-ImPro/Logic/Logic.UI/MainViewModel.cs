using System.Diagnostics;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace OE.NIK.ImPro.Logic.UI
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            //if (IsInDesignMode)
            //{
                                           
            //}
            //else
            //{
                
            //}

            OpenPictureCommand = new RelayCommand(
                () => {
                    Trace.TraceInformation("OK!");
                });
        }

        /// <summary>
        /// Gets the title of the main window
        /// </summary>
        public string WindowTitle => "ImPro";

        /// <summary>
        /// Gets the name of the program
        /// </summary>
        public string ProgramName => "ImPro - Image Processer";

        public RelayCommand OpenPictureCommand { get; private set; }

    }
}