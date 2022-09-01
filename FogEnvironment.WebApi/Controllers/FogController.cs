using FogEnvironment.Domain.Model.TaskModels;
using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace FogEnvironment.WebApi.Controllers
{
    public class FogController : Web.ControllerBase
    {
        private readonly INodeDecorator _nodeDecorator;

        public FogController(INodeDecorator nodeDecorator)
        {
            _nodeDecorator = nodeDecorator;
        }

        [HttpGet]
        public IActionResult Test() => Content("Test!");

        [HttpPost]
        public async Task<IActionResult> UploadPhoto([FromForm] RequestViewModel viewModel)
        {
            var st = new Stopwatch();

            st.Start();
            var statistics = await _nodeDecorator.ManageAndExecuteTasksAsync(viewModel.File.Select(q => new UserTaskRequest
            {
                Image = q.ByteArrayFormImage,
                UserTask = q.TaskTypes,
                ImageSizeOnDisk = q.FileSize,
                FileName = q.FileName,
            }).ToList()
           );

            st.Stop();
            statistics.ElepsedTime = st.Elapsed;

            try
            {
                var resp = JsonConvert.SerializeObject(statistics
                       , Formatting.Indented,
                               new JsonSerializerSettings
                               {
                                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                                   PreserveReferencesHandling = PreserveReferencesHandling.Objects
                               }
                       );
                return Ok(resp);
            }
            catch (Exception e)
            {

                throw;
            }
           
        }
    }
}
