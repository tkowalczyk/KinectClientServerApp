using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//using Microsoft.Kinect;
using Coding4Fun.Kinect.KinectService.Common;
using Coding4Fun.Kinect.KinectService.WpfClient;
using ColorImageFormat = Microsoft.Kinect.ColorImageFormat;
using DepthImageFormat = Microsoft.Kinect.DepthImageFormat;
using ImageFrame = Microsoft.Kinect.ImageFrame;

namespace KinectWpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ColorClient _colorClient = new ColorClient();
        string _serverAddress = String.Empty;

        public MainWindow()
        {
            InitializeComponent();
            _colorClient.ColorFrameReady += new EventHandler<ColorFrameReadyEventArgs>(colorClient_ColorFrameReady);
        }

        void colorClient_ColorFrameReady(object sender, ColorFrameReadyEventArgs e)
        {
            imageColor.Source = e.ColorFrame.BitmapImage;
        }

        private void bConnect_Click(object sender, RoutedEventArgs e)
        {
            _serverAddress = tbIP.Text.ToString();
            _colorClient.Connect(_serverAddress, 4530);
        }

        private void bDisconnect_Click(object sender, RoutedEventArgs e)
        {
            if (_colorClient.IsConnected)
            {
                _colorClient.Disconnect();
            }
        }
    }
}
