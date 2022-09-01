using FogEnvironment.Domain.Enum;

namespace FogEnvironment.WebApi.ViewModels
{
    public class RequestViewModel
    {
        public List<RequestDetail> File { get; set; }
    }

    public class RequestDetail
    {
        public IFormFile Image { get; set; }
        public string FileName { get 
            {
                return Image.FileName;
            }
        }
        public string Name { get; set; }

        public List<TaskType> TaskTypes
        {
            get
            {
                if (!string.IsNullOrEmpty(Name))
                return Name.Split(",").Select(x => Enum.Parse(typeof(TaskType), x))
                           .Cast<TaskType>()
                           .ToList();

                return null;
            }
        }

        public byte[] ByteArrayFormImage
        {
            get
            {
                if(Image is not null)
                if (Image.Length > 0)
                {
                    using var fileStream = Image.OpenReadStream();
                    byte[] bytes = new byte[Image.Length];
                    fileStream.Read(bytes, 0, (int)Image.Length);

                    return bytes;
                }
                return null;
            }
        }

        public long FileSize
        {
            get { if (Image is not null) return Image.Length; else return 0; }
        }
    }
}
