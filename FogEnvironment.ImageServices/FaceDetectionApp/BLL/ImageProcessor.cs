using Accord.Imaging.Filters;
using System.Drawing;

namespace FaceDetectionApp
{
    public class ImageProcessor
    {
        private Bitmap _bitmap;
        public Bitmap Result { get => _bitmap; }
        public ImageProcessor(Bitmap bitmap)
        {
            _bitmap = bitmap;
        }
        public ImageProcessor Grayscale()
        {
            var grayscale = new Grayscale(0.2125, 0.7154, 0.0721);
            _bitmap = grayscale.Apply(_bitmap);
            return this;
        }

        public ImageProcessor EqualizeHistogram()
        {
            HistogramEqualization filter = new HistogramEqualization();
            filter.ApplyInPlace(_bitmap);
            return this;
        }

        public ImageProcessor Resize(Size size)
        {
            _bitmap = new Bitmap(_bitmap, size);
            return this;
        }
    }
}