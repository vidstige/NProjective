using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KinectICP.ViewModels
{
    class MainViewModel: ViewModel
    {
        private KinectSensor _sensor;
        private WriteableBitmap _bitmap;

        public MainViewModel()
        {
            _bitmap = new WriteableBitmap(640, 480, 96, 96, PixelFormats.Gray8, null);
        }

        public WriteableBitmap DepthMap
        {
            get { return _bitmap; }
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
                    var buff = pixels.Select(pixel => (byte)(256-pixel.Depth / 256)).ToArray();
                    var rect = new Int32Rect(0, 0, 640, 480);
                    const int stride = 640;
                    _bitmap.WritePixels(rect, buff, stride, 0);
                }
            }
        }
    }
}
