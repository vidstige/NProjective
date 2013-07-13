using Microsoft.Kinect;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KinectICP.ViewModels
{
    class MainViewModel: ViewModel
    {
        private KinectSensor _sensor;
        private readonly DepthMapPainter _depthMapPainter;

        public MainViewModel()
        {
            _depthMapPainter = new DepthMapPainter();
        }

        public ImageSource DepthMap
        {
            get { return _depthMapPainter.Bitmap; }
        }

        public ICommand Start { get { return new DelegatingCommand(StartSensor); } }

        public void StartSensor(object parameter)
        {
            _sensor = KinectSensor.KinectSensors.First();
            var depthStream = _sensor.DepthStream;
            depthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            _sensor.DepthFrameReady += _sensor_DepthFrameReady;
            _sensor.Start();
        }

        private void _sensor_DepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (var frame = e.OpenDepthImageFrame())
            {
                if (frame != null)
                {
                    DepthImagePixel[] pixels = new DepthImagePixel[frame.PixelDataLength];
                    frame.CopyDepthImagePixelDataTo(pixels);
                    short[] buff = pixels.Select(pixel => pixel.Depth).ToArray();
                    _depthMapPainter.UpdateWith(buff);
                }
            }
        }
    }
}
