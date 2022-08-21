using FaceDetectionApp;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FogEnvironment.ImageProcessService.BLL
{
    public class ImageUtilities
    {
        private FaceDetector _faceDetector = new FaceDetector();

        public async Task<IEnumerable<Face>> FaceDetection(Bitmap image)
        {
            IEnumerable<Face> faces = new List<Face>();
            await Task.Run(() =>
            {
                faces = _faceDetector.ExtractFaces(new ImageProcessor(image).Grayscale()
                         .EqualizeHistogram().Result);
            });

            return faces;
        }


        public async Task<Bitmap> HorizontalFlip(Bitmap image)
        {
            int w = image.Width;
            int h = image.Height;
            using (Bitmap resimg = new Bitmap(w, h))
            {
                await Task.Run(() =>
                {
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

                    BitmapData rd = resimg.LockBits(new Rectangle(0, 0, w, h),
                        ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
                    Marshal.Copy(result, 0, rd.Scan0, bytes);
                    resimg.UnlockBits(rd);
                });

                return resimg;
            }
        }

        public async Task<Bitmap> ConvertToBlackandWhite(Bitmap image)
        {
            using (Bitmap bitmap = new Bitmap(image))
            {
                await Task.Run(() =>
                {
                    for (int i = 0; i < bitmap.Width; i++)
                    {
                        for (int j = 0; j < bitmap.Height; j++)
                        {
                            int ser = (bitmap.GetPixel(i, j).R + bitmap.GetPixel(i, j).G + bitmap.GetPixel(i, j).B) / 3;
                            bitmap.SetPixel(i, j, Color.FromArgb(ser, ser, ser));
                        }
                    }
                });
                return bitmap;
            }
        }

        public async Task<Bitmap> CreateThumbnail(Bitmap imgOriginal, int ThumbnailMax = 200)
        {
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

            using (Bitmap ThumbnailBitmap = new Bitmap(ThumbnailWidth, ThumbnailHeight))
            {
                await Task.Run(() =>
                {
                    Graphics ResizedImage = Graphics.FromImage(ThumbnailBitmap);
                    ResizedImage.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    ResizedImage.CompositingQuality = CompositingQuality.HighQuality;
                    ResizedImage.SmoothingMode = SmoothingMode.HighQuality;
                    ResizedImage.DrawImage(imgOriginal, 0, 0, ThumbnailWidth, ThumbnailHeight);
                });

                return ThumbnailBitmap;
            }
        }
    }
}
