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

        public void UpdateWith(DepthImageFrame frame)
        {
            DepthImagePixel[] pixels = new DepthImagePixel[frame.PixelDataLength];
            frame.CopyDepthImagePixelDataTo(pixels);
            short[] buff = pixels.Select(pixel => (short)(32000 - pixel.Depth)).ToArray();
            var rect = new Int32Rect(0, 0, 640, 480);
            int stride = rect.Width * _bitmap.Format.BitsPerPixel / 8;
            _bitmap.WritePixels(rect, buff, stride, 0);
        }

        public ImageSource Bitmap { get { return _bitmap; } }
    }
}
