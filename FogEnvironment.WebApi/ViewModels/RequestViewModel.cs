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
        public string Name { get; set; }

        public List<TaskType> TaskTypes
        {
            get { return Name.Split(",").Cast<TaskType>().ToList(); }
            set { }
        }

        public byte[] ByteArrayFormImage
        {
            get
            {
                if (Image.Length > 0)
                {
                    using var fileStream = Image.OpenReadStream();
                    byte[] bytes = new byte[Image.Length];
                    fileStream.Read(bytes, 0, (int)Image.Length);

                    return bytes;
                }
                return null;
            }
            set { }
        }

        public long FileSize
        {
            get { return Image.Length; }
            set { }
        }
    }
}
