using System.Collections.Generic;

namespace NProjective
{
    public class PointCloundConverter
    {
        public PointCloud Convert(short[] depthImageBuffer, int width, int height, int stride, float focalPoint)
        {
            List<Point3d> result = new List<Point3d>(width * height);
            
            float constant = 1.0f / focalPoint;  // 525 for kinect
            int depth_idx = 0; 
            int centerX = width / 2;
            int centerY = height / 2;
            for (int v = -centerY; v < centerY; v++) 
            {
                for (int u = -centerX; u < centerX; u++) 
                {
                    float z = depthImageBuffer[depth_idx] * 0.001f;
                    result.Add(new Point3d((float)u * z * constant, (float)v * z * constant, z));
                    depth_idx++;
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
