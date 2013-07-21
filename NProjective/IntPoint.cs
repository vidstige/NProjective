using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NProjective
{
    public class Point<T>
    {
        private readonly T _x;
        private readonly T _y;

        public Point(T x, T y)
        {
            _x = x;
            _y = y;
        }

        public T X { get { return _x; } }
        public T Y { get { return _y; } }
    }

    public class IntPoint: Point<int>
    {
        private readonly int _index;
        public IntPoint(int x, int y, int index): base(x, y)
        {
            _index = index;
        }
        public int Index { get { return _index; } }
    }
}
