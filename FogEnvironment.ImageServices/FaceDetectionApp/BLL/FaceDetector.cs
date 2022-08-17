using Accord.Vision.Detection;
using Accord.Vision.Detection.Cascades;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FaceDetectionApp
{
    internal class FaceDetector
    {
        private HaarObjectDetector _detector;

        public FaceDetector()
        {
            _detector = new HaarObjectDetector(new FaceHaarCascade());
        }

        internal IEnumerable<Face> ExtractFaces(Bitmap picture, FaceDetectorParameters faceDetectorParameters) =>
            picture == null ?
            Enumerable.Empty<Face>() :
            ProcessFrame(picture, faceDetectorParameters).Select(rec => new Face(rec));

        private IEnumerable<Rectangle> ProcessFrame(Bitmap picture, FaceDetectorParameters faceDetectorParameters)
        {
            _detector.MinSize = new Size(faceDetectorParameters.MinimumSize, faceDetectorParameters.MinimumSize);
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