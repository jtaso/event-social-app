using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // 'controller' is a placeholder that gets replaced with controller class name
    public class BaseApiController : ControllerBase
    {

    }
}