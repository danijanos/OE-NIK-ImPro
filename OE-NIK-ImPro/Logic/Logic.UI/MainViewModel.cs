using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;

namespace OE.NIK.ImPro.Logic.UI
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.     
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            OpenPictureCommand = new RelayCommand(
                () =>
                {
                    BrowseAndOpenPictureFile();
                    IsAPicture = true;
                    HistogramCommand.RaiseCanExecuteChanged();
                }
                );

            HistogramCommand = new RelayCommand(
                () => MessengerInstance.Send(new HistogramPresenter("Hello!"))                ,
                () => IsAPicture
                );
        }

        private void BrowseAndOpenPictureFile()
        {
            var fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*",
                DefaultExt = ".JPG"
            };

            if (fileDialog.ShowDialog() == true)
            {                   
                SourceOfTheSelectedImage = fileDialog.FileName;                
            }
        }

        /// <summary>
        /// Gets or sets the source of the image
        /// </summary>
        public string SourceOfTheSelectedImage {get; set;}

        /// <summary>
        /// Indicates that the opened file is a picture or not
        /// </summary>
        public bool IsAPicture { get; set; }

        /// <summary>
        /// Command for open picture button
        /// </summary>
        public RelayCommand OpenPictureCommand { get; }

        /// <summary>
        /// Command for create histogram button
        /// </summary>
        public RelayCommand HistogramCommand { get; }

    }
}