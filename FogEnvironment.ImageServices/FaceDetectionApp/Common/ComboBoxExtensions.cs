﻿using System;
using System.Windows.Forms;

namespace FaceDetectionApp
{
    public static class ComboBoxExtensions
    {
        public static void LoadAndSetDefaultFromEnum<T>(this ComboBox comboBox, T selectItem) where T : Enum
        {
            comboBox.DataSource = Enum.GetValues(typeof(T));
            comboBox.SelectedItem = selectItem;
        }
    }
}
