using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // 'controller' is a placeholder that gets replaced with controller class name
    public class BaseApiController : ControllerBase
    {
        // Make mediator available to any derived classes from the base API controller
        private IMediator _mediator;

        // Abailable to this class and any derived classes
        // ??= null coalescing assignment operator, if mediator is null -> assign to mediator service
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}