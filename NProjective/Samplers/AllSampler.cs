using System.Collections.Generic;
namespace NProjective.Samplers
{
    public class AllSampler: ISampler
    {
        public IEnumerable<IntPoint> SampleCoordinates(int width, int height, int stride)
        {
            int depth_idx = 0;
            int centerX = width / 2;
            int centerY = height / 2;
            for (int v = -centerY; v < centerY; v++)
            {
                for (int u = -centerX; u < centerX; u++)
                {
                    yield return new IntPoint(v, u, depth_idx++);
                }
                depth_idx += stride - width;
            }
        }
    }
}
