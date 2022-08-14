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
    }
}
