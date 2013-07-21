using NProjective.Samplers;
using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace NProjective
{
    public class PointCloundConverter
    {
        private readonly ISampler _sampler;

        public PointCloundConverter(ISampler sampler)
        {
            _sampler = sampler;
        }

        public PointCloud Convert(short[] depthImageBuffer, int width, int height, int stride, float focalPoint)
        {
            var result = new List<Point3D>(width * height);

            double constant = 1.0f / focalPoint;  // 525 for kinect

            foreach (var pt in _sampler.SampleCoordinates(width, height, stride))
            {
                if (depthImageBuffer[pt.Index] > 0)
                {
                    double z = depthImageBuffer[pt.Index] * 0.001f;
                    result.Add(new Point3D((double)pt.X * z * constant, (double)pt.Y * z * constant, z));
                }
            }

            //pointcloud.sensor_origin_.setZero (); 
            //pointcloud.sensor_orientation_.w () = 0.0f; 
            //pointcloud.sensor_orientation_.x () = 1.0f; 
            //pointcloud.sensor_orientation_.y () = 0.0f; 
            //pointcloud.sensor_orientation_.z () = 0.0f; 

            return new PointCloud(result);
        }
    }
}
