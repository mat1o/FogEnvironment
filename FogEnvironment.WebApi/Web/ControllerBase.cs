using Microsoft.AspNetCore.Mvc;

namespace FogEnvironment.WebApi.Web
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
    }
}
