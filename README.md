KinectClientServerApp
=====================

This simple application shows how to properly use [Kinect for Windows SDK](http://www.microsoft.com/en-us/kinectforwindows/ "Kinect for Windows SDK") with Kinect device in the client-server application.

In this example we will use [Coding4Fun Kinect Service](http://kinectservice.codeplex.com/ "Coding4Fun Kinect Service") library hosted on [Codeplex](http://www.codeplex.com/ "Codeplex"). Solution will consist of two projects: simple console app which will be working as server side and simple WPF app as client side.

**How does it work? (server app)**

We need to download [Coding4Fun Kinect Service](http://kinectservice.codeplex.com/ "Coding4Fun Kinect Service") library, [Nuget](https://nuget.org/packages/Coding4Fun.Kinect.KinectService.Listeners "NuGet") is the best way to do this in my opinion. First things first so define some ports for listeners:

`private static readonly int VideoPort = 4530;
        private static readonly int AudioPort = 4531;
        private static readonly int DepthPort = 4532;
        private static readonly int SkeletonPort = 4533;`

Next listeners objects. Each listener is defined for each stream:

`private static DepthListener _depthListener;
        private static ColorListener _videoListener;
        private static SkeletonListener _skeletonListener;
        private static AudioListener _audioListener;`

and sensor object:

`private static KinectSensor _kinect;`

Then we have to some streams enabled for example:

`_kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);`

And setup listener:

`_videoListener = new ColorListener(_kinect, VideoPort, ImageFormat.Jpeg);
			_videoListener.Start();`

Last step in server side is to setup address:

`IPAddress[] addresses = Dns.GetHostAddresses(Dns.GetHostName());`

**How does it work? (client app)**

We have to define client object for each stream we are going to receive:

`ColorClient _colorClient = new ColorClient();`

In this example we have simple Connect button to connect the server:

`_serverAddress = tbIP.Text.ToString();
            _colorClient.Connect(_serverAddress, 4530);`

In constructor we have to call event method which will be fired when data will be send by server:

`_colorClient.ColorFrameReady += new EventHandler<ColorFrameReadyEventArgs>(colorClient_ColorFrameReady);`

And simple attach data to the image control, defined in `*.xaml`:

`imageColor.Source = e.ColorFrame.BitmapImage;`

**More examples**

Feel free to visit my homepage [Tomasz Kowalczyk](http://tomek.kownet.info/ "Tomasz Kowalczyk") to see more complex examples.
