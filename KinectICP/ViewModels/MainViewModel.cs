using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KinectICP.ViewModels
{
    class MainViewModel: ViewModel
    {
        private WriteableBitmap _bitmap;

        public MainViewModel()
        {
            _bitmap = new WriteableBitmap(320, 200, 96, 96, PixelFormats.Gray16, null);
        }

        public WriteableBitmap DepthMap
        {
            get { return _bitmap; }
        }

        public ICommand Start { get { return new DelegatingCommand(StartSensor); } }

        public void StartSensor(object parameter)
        {
            var sensor = KinectSensor.KinectSensors.First();
            var depthStream = sensor.DepthStream;
            depthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
            var frame = depthStream.OpenNextFrame(1000 / 30);
            depthStream.Disable();
        }

    }
}
