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
                () => 
                {
                    Trace.TraceInformation("Open picture button pressed!");
                    IsAPicture = true;
                    HistogramCommand.RaiseCanExecuteChanged();
                }                             
                );

            HistogramCommand = new RelayCommand(
                () =>
                {
                    Trace.TraceInformation("Create histogram button pressed!");
                },
                () => IsAPicture
                );
        }

        /// <summary>
        /// Indicates that the opened file is a picture or not
        /// </summary>
        public bool IsAPicture { get; set; } = false;

        /// <summary>
        /// Gets the title of the main window
        /// </summary>
        public string WindowTitle => "ImPro";

        /// <summary>
        /// Gets the name of the program
        /// </summary>
        public string ProgramName => "ImPro - Image Processer";

        /// <summary>
        /// Command for open picture button
        /// </summary>
        public RelayCommand OpenPictureCommand { get; private set; }

        /// <summary>
        /// Command for create histogram button
        /// </summary>
        public RelayCommand HistogramCommand { get; private set; }

    }
}