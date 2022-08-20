using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FogEnvironment.WebApi.Controllers
{
    public class FogController : Web.ControllerBase
    {
        private readonly INodeDecorator _nodeDecorator;

        public FogController(INodeDecorator nodeDecorator)
        {
            _nodeDecorator = nodeDecorator;
        }

        [HttpPost]
        public string UploadPhoto([FromForm] RequestViewModel viewModel)
        {
            var test = _nodeDecorator.ManageAndExecuteTasksAsync(viewModel.File.Select(q => new UserTaskRequest
            {
                Image = q.ByteArrayFormImage,
                UserTask = q.TaskTypes,
                ImageSizeOnDisk = q.FileSize
            }).ToList()
            );

            return "";
        }
    }
}
