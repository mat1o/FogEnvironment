using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FogEnvironment.Domain.Model.AppSettingModels
{
    public class TasksVolume
    {
        public int FaceDetection { get; set; }
        public int Resize { get; set; }
        public int Thumbnail { get; set; }
        public int ChangeExtention { get; set; }
    }
}
