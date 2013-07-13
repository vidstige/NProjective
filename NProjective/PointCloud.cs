using System.Collections.Generic;
using System.Windows.Media.Media3D;

namespace NProjective
{
    public class PointCloud
    {
        private readonly IList<Point3D> _points;

        public PointCloud(IList<Point3D> points)
        {
            _points = points;
        }

        public IList<Point3D> Points { get { return _points; } }
    }
}
