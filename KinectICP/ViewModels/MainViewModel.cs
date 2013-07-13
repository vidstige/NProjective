using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinectICP.ViewModels
{
    class MainViewModel: ViewModel
    {
        public bool IsConnected
        {
            get
            {
                //var sensor = KinectSensor.KinectSensors.First();
                //var depthStream = sensor.DepthStream;
                //depthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                //var frame = depthStream.OpenNextFrame(1000 / 30);
                //depthStream.Disable();
                return false;
            }
        }

        public void Refresh()
        {
            RaisePropertyChanged("IsConnected");
        }
    }
}
