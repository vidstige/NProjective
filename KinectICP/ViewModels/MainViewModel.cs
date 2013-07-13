using Microsoft.Kinect;
using NProjective;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace KinectICP.ViewModels
{
    class MainViewModel: ViewModel
    {
        private KinectSensor _sensor;
        private readonly DepthMapPainter _depthMapPainter;

        private IList<Point3D> _points;

        public MainViewModel()
        {
            _depthMapPainter = new DepthMapPainter();
        }

        public ImageSource DepthMap
        {
            get { return _depthMapPainter.Bitmap; }
        }

        public IList<Point3D> Points
        {
            get { return _points; }
            set
            {
                _points = value;
                RaisePropertyChanged("Points");
            }
        }

        public ICommand Start { get { return new DelegatingCommand(StartSensor); } }

        public void StartSensor(object parameter)
        {
            _sensor = KinectSensor.KinectSensors.First();
            var depthStream = _sensor.DepthStream;
            depthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
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
                    
                    //_depthMapPainter.UpdateWith(buff);
                    if (frame.FrameNumber % 30 == 0)
                    {
                        Points = new PointCloundConverter().Convert(buff, frame.Width, frame.Height, frame.Width, 525f).Points;
                    }
                }
            }
        }
    }
}
