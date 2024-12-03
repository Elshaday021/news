using HCMS.Api.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.API.Controllers
{
    [ApiController]
    [ServiceFilter(typeof(ApiExceptionFilterAttribute))]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private IMediator? _mediator;
        private ILogger<T> _logger;

        protected IMediator mediator => _mediator ??=
             HttpContext.RequestServices.GetService<IMediator>();
        protected ILogger<T> logger => _logger ??=
            HttpContext.RequestServices.GetService<ILogger<T>>();
    }
}
