using System;
using System.Collections.Generic;

namespace NProjective.Samplers
{
    public class RandomSampler: ISampler
    {
        private readonly int _n;
        private readonly Random _random;

        public RandomSampler(int n)
        {
            _n = n;
            _random = new Random();
        }

        public IEnumerable<IntPoint> SampleCoordinates(int width, int height, int stride)
        {
            for (int i = 0; i < _n; i++)
            {
                int x = _random.Next(width);
                int y = _random.Next(height);
                yield return new IntPoint(x, y, y * stride + x);
            }
        }
    }
}
