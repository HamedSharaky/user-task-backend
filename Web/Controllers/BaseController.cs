using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace UserTask.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        protected IMediator Mediator => _mediator ??/*=*/ HttpContext.RequestServices.GetService<IMediator>();
    }
}
