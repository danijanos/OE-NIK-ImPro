using GalaSoft.MvvmLight;

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
            if (IsInDesignMode)
            {
                WindowTitle = "ImPro (design)";                
            }
            else
            {
                WindowTitle = "ImPro";                
            }
        }

        /// <summary>
        /// Gets the title of the main window
        /// </summary>
        public string WindowTitle { get; private set; }

        public string ProgramName { get; private set; } = "ImPro - Image Processer";
    }
}