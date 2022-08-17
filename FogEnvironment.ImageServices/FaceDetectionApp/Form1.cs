using System;
using System.Drawing;
using System.Windows.Forms;
using Accord.Vision.Detection;

namespace FaceDetectionApp
{
    public partial class Form1 : Form
    {
        private Bitmap _selectedPicture;
        private FaceDetector _faceDetector = new FaceDetector();

        public float ScaleFactor { get; set; } = 1.1f;
        public int MinSize { get; set; } = 5;
        public ObjectDetectorScalingMode ScaleMode { get; set; } = ObjectDetectorScalingMode.GreaterToSmaller;
        public ObjectDetectorSearchMode SearchMode { get; set; } = ObjectDetectorSearchMode.Average;
        public bool Parallel { get; set; } = true;
        public Form1()
        {
            InitializeComponent();

            cbMode.LoadAndSetDefaultFromEnum(ObjectDetectorSearchMode.NoOverlap);
            cbScaling.LoadAndSetDefaultFromEnum(ObjectDetectorScalingMode.SmallerToGreater);

            txtScaleFactor.DataBindings.Add("Text", this, "ScaleFactor");
            txtSize.DataBindings.Add("Text", this, "MinSize");
            cbScaling.DataBindings.Add("SelectedItem", this, "ScaleMode");
            cbMode.DataBindings.Add("SelectedItem", this, "SearchMode");
            cbParallel.DataBindings.Add("Checked", this, "Parallel");
        }

        private void btnOpenImage_Click(object sender, EventArgs e)=>
            new OpenImageFileDialog().OpenImage((selectedFile) => { _selectedPicture = new Bitmap(selectedFile); pictureBox1.Image = _selectedPicture; });

        private void btnDetect_Click(object sender, EventArgs e)=>
            new ImageSelector(_selectedPicture).IsValidImage((pic) =>
                _faceDetector.ExtractFaces(
                    new ImageProcessor(pic).Grayscale().EqualizeHistogram().Result,
                    FaceDetectorParameters.Create(ScaleFactor, MinSize, ScaleMode, SearchMode, Parallel))
                .HasElements(pictureBox1.Refresh)
                .ForEach((face) => pictureBox1.DrawRectangle(
                        face.FaceRectangle,
                        Color.Red,
                        width: 2)));
    }
}
