using FogEnvironment.Domain.Enum;

namespace FogEnvironment.WebApi.ViewModels
{
    public class RequestViewModel
    {
        public RequestViewModel()
        {
            Id = Guid.NewGuid();    
        }

        public Guid Id { get; set; }
       //public string PictureLocation { get; set; }
        public IFormFile File { get; set; }
        public string Name { get; set; }
        //public string FileName { get; set; }
        // public List<TaskType> MyProperty { get; set; }
    }
}
