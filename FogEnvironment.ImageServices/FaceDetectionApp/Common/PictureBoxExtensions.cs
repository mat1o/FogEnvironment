using System.Drawing;
using System.Windows.Forms;

namespace FaceDetectionApp
{
    public static class PictureBoxExtensions
    {
        public static void DrawRectangle(this PictureBox pictureBox, Rectangle rectangle, Color color, float width)
        {
            using (var g = pictureBox.CreateGraphics())
            {
                g.DrawRectangle(new Pen(new SolidBrush(color), width), rectangle);
            }
        }
    }
}
