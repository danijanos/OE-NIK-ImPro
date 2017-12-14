using System.Collections.Generic;
using System.Drawing;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using OE.NIK.ImPro.Logic.UI.Models;

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
                    HistogramCommand.RaiseCanExecuteChanged();
                    GrayscaleCommand.RaiseCanExecuteChanged();
                }
                );

            HistogramCommand = new RelayCommand(
                () => MessengerInstance.Send(new HistogramPresenter(BitmapFromImage)),
                () => IsOpened
                );

            GrayscaleCommand = new RelayCommand(
                () =>
                {
                    new ColorToGrayscaleConverter(BitmapFromImage);
                    BitmapFromImage.Save(SourceOfTheSelectedImage + ".jpg");
                    SourceOfTheSelectedImage += ".jpg";
                    FilesToDeleteWhenQuit.Add(SourceOfTheSelectedImage);
                },
                () => IsOpened
                );
        }

        /// <summary>
        /// Property which stores file paths which should be deleted when the application closes
        /// </summary>
        public static List<string> FilesToDeleteWhenQuit { get; private set; } = new List<string>();

        /// <summary>
        /// Stores the selected image as a Bitmap for further processing
        /// </summary>
        public Bitmap BitmapFromImage { get; set; }

        /// <summary>
        /// Gets or sets the URI source of the image
        /// </summary>
        public string SourceOfTheSelectedImage { get; set; }

        /// <summary>
        /// Indicates that the image file was opened or not
        /// </summary>
        public bool IsOpened { get; set; }

        private void CreateBitmapFromSourceImage()
        {
            BitmapFromImage = (Bitmap)Image.FromFile(SourceOfTheSelectedImage);
        }

        private void BrowseAndOpenPictureFile()
        {
            var fileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF",
                DefaultExt = ".JPG"
            };

            if (fileDialog.ShowDialog() == true)
            {
                SourceOfTheSelectedImage = fileDialog.FileName;
                CreateBitmapFromSourceImage();
                IsOpened = true;
            }
        }

        /// <summary>
        /// Command for open picture button
        /// </summary>
        public RelayCommand OpenPictureCommand { get; }

        /// <summary>
        /// Command for histogram button
        /// </summary>
        public RelayCommand HistogramCommand { get; }

        /// <summary>
        /// Command for histogram button
        /// </summary>
        public RelayCommand GrayscaleCommand { get; }

        /// <summary>
        /// Command for invert button
        /// </summary>
        public RelayCommand InvertCommand { get; set; }
    }
}