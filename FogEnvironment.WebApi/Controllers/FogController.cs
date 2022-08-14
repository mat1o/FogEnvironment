using FogEnvironment.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace FogEnvironment.WebApi.Controllers
{
    public class FogController : Web.ControllerBase
    {

        //endpint -> id
        //id resize
        //id crop 

        //model list 


        [HttpGet]
        public IActionResult Test(int n)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult FogEnvironmentRequestHub(RequestViewModel requestViewModel)
        {

            return Ok();
        }

        [HttpPost]
        public string UploadPhoto([FromForm] RequestViewModel viewModel)
        {
            return "";
        }
    }
}
