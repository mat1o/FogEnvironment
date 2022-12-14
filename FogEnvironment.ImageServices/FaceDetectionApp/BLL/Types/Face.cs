using System.Drawing;

namespace FogEnvironment.ImageProcessService
{
    public class Face
    {
        private Rectangle _selectionRectangle;

        public Face(Rectangle selectionRectangle)
        {
            _selectionRectangle = selectionRectangle;
        }

        public Rectangle FaceRectangle { get => _selectionRectangle; }

        public override string ToString() =>
            $"X: {_selectionRectangle.X}, Y: {_selectionRectangle.Y}, Width: {_selectionRectangle.Width}, Height: {_selectionRectangle.Height}";
    }
}