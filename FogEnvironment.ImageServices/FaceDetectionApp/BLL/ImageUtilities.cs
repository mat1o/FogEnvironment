using FaceDetectionApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace FogEnvironment.ImageProcessService.BLL
{
    public class ImageUtilities
    {
        private FaceDetector _faceDetector = new FaceDetector();

        public IEnumerable<Face> FaceDetection(Bitmap image) =>
            _faceDetector.ExtractFaces(new ImageProcessor(image)
                .Grayscale()
                .EqualizeHistogram()
                .Result);

        public Bitmap HorizontalFlip(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;
            BitmapData sd = image.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            int bytes = sd.Stride * sd.Height;
            byte[] buffer = new byte[bytes];
            byte[] result = new byte[bytes];
            Marshal.Copy(sd.Scan0, buffer, 0, bytes);
            image.UnlockBits(sd);
            int current, flipped = 0;
            for (int y = 0; y < h; y++)
            {
                for (int x = 4; x < w; x++)
                {
                    current = y * sd.Stride + x * 4;
                    flipped = y * sd.Stride + (w - x) * 4;
                    for (int i = 0; i < 3; i++)
                    {
                        result[flipped + i] = buffer[current + i];
                    }
                    result[flipped + 3] = 255;
                }
            }
            Bitmap resimg = new Bitmap(w, h);
            BitmapData rd = resimg.LockBits(new Rectangle(0, 0, w, h),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, rd.Scan0, bytes);
            resimg.UnlockBits(rd);

            return resimg;
        }

        public Bitmap ConvertToBlackandWhite(Bitmap image)
        {
            Bitmap bitmap = new Bitmap(image);
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int ser = (bitmap.GetPixel(i, j).R + bitmap.GetPixel(i, j).G + bitmap.GetPixel(i, j).B) / 3;
                    bitmap.SetPixel(i, j, Color.FromArgb(ser, ser, ser));
                }
            }
            return bitmap;
        }

        public Bitmap CreateThumbnail(Bitmap image, int ThumbnailMax = 200)
        {
            Bitmap imgOriginal = image;
            float OriginalHeight = imgOriginal.Height;
            float OriginalWidth = imgOriginal.Width;
            int ThumbnailWidth;
            int ThumbnailHeight;
            if (OriginalHeight > OriginalWidth)
            {
                ThumbnailHeight = ThumbnailMax;
                ThumbnailWidth = (int)((OriginalWidth / OriginalHeight) * (float)ThumbnailMax);
            }
            else
            {
                ThumbnailWidth = ThumbnailMax;
                ThumbnailHeight = (int)((OriginalHeight / OriginalWidth) * (float)ThumbnailMax);
            }
            Bitmap ThumbnailBitmap = new Bitmap(ThumbnailWidth, ThumbnailHeight);
            Graphics ResizedImage = Graphics.FromImage(ThumbnailBitmap);
            ResizedImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
            ResizedImage.CompositingQuality = CompositingQuality.HighQuality;
            ResizedImage.SmoothingMode = SmoothingMode.HighQuality;
            ResizedImage.DrawImage(imgOriginal, 0, 0, ThumbnailWidth, ThumbnailHeight);

            return ThumbnailBitmap;
        }
    }
}
