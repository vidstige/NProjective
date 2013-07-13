using System.Linq;
using Microsoft.Kinect;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace KinectICP.ViewModels
{
    class DepthMapPainter
    {
        private readonly WriteableBitmap _bitmap = new WriteableBitmap(640, 480, 96, 96, PixelFormats.Gray16, null);
        private const int _bitsPerByte = 8;

        public void UpdateWith(short[] buff)
        {
            var rect = new Int32Rect(0, 0, 640, 480);
            int stride = rect.Width * _bitmap.Format.BitsPerPixel / _bitsPerByte;
            _bitmap.WritePixels(rect, buff, stride, 0);
        }

        public ImageSource Bitmap { get { return _bitmap; } }
    }
}
