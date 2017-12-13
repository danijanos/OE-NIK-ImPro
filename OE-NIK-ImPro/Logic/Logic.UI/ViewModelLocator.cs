/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:OE.NIK.ImPro.UI.Desktop"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace OE.NIK.ImPro.Logic.UI
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HistogramViewModel>();
        }

        /// <summary>
        /// Retrives the view model for the main view
        /// </summary>
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public HistogramViewModel HistogramViewModel => ServiceLocator.Current.GetInstance<HistogramViewModel>();

        public static void Cleanup()
        {
            // TODO: Delete temp files
            if (MainViewModel.FilesToDeleteWhenQuit.Any())
            {
                foreach (string path in MainViewModel.FilesToDeleteWhenQuit)
                {
                    // TODO: 
                    try
                    {
                        File.Delete(path);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);                        
                    }
                }
            }
            // TODO Clear the ViewModels
        }
    }
}