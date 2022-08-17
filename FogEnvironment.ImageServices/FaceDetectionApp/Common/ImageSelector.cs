﻿using System;
using System.Drawing;

namespace FaceDetectionApp
{
    internal class ImageSelector
    {
        private Bitmap _picture;

        public ImageSelector(Bitmap picture)
        {
            _picture = picture;
        }

        internal void IsValidImage(Action<Bitmap> action)
        {
            if (_picture == null) return;
            action(_picture);
        }
    }
}