using System;
using GalaSoft.MvvmLight.Messaging;
using OE.NIK.ImPro.Logic.UI;

namespace OE.NIK.ImPro.UI.Desktop
{
    public class MessageListener
    {
        /// <summary>
        /// Initialize a new instance of <see cref="MessageListener"/> class
        /// </summary>
        public MessageListener()
        {
            InitMessenger();
        }

        /// <summary>
        /// Called by the constructor to define the message we are interested in
        /// </summary>
        private void InitMessenger()
        {
            Messenger.Default.Register<HistogramPresenter>(
                this,
                msg =>
                {
                    var window = new HistogramWindow();
                    var model = window.DataContext as HistogramViewModel;
                    if (model != null)
                    {
                        Console.WriteLine(msg.TestText);
                    }
                    window.ShowDialog();
                });
        }

        /// <summary>
        /// Property to help put this type into the resources
        /// </summary>
        public bool BindableProperty => true;
    }
}
