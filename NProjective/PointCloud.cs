using System.Collections.Generic;

namespace NProjective
{
    public class PointCloud
    {
        private readonly IList<Point3d> _points;

        public PointCloud(IList<Point3d> points)
        {
            _points = points;
        }

        public IList<Point3d> Points { get { return _points; } }
    }
}
