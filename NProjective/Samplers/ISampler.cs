using System.Collections.Generic;

namespace NProjective.Samplers
{
    public interface ISampler
    {
        IEnumerable<IntPoint> SampleCoordinates(int width, int height, int stride);
    }
}
