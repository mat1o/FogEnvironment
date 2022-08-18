using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace FaceDetectionApp
{
    public class FaceDetector
    {
        public HaarObjectDetector _detector;

        public FaceDetector()
        {
            _detector = new HaarObjectDetector(new FaceHaarCascade());
        }

        public IEnumerable<Face> ExtractFaces(Bitmap picture) =>
            picture == null ?
            Enumerable.Empty<Face>() :
            ProcessFrame(picture).Select(rec => new Face(rec));

        public IEnumerable<Rectangle> ProcessFrame(Bitmap picture)
        {
            _detector.MinSize = new Size(5, 5);
            _detector.ScalingFactor = 1.1f;
            _detector.ScalingMode = ObjectDetectorScalingMode.GreaterToSmaller;
            _detector.SearchMode = ObjectDetectorSearchMode.Single;
            _detector.UseParallelProcessing = true;
            _detector.MaxSize = new Size(600, 600);
            _detector.Suppression = 1;
            return _detector.ProcessFrame(picture);
        }
    }
}