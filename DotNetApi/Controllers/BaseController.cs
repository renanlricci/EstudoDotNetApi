using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace DotNetApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        private readonly ILogger<BaseController> _log;

        public BaseController(IMediator mediator, ILoggerFactory loggerFactory)
        {
            _mediator = mediator;
            _log = loggerFactory.CreateLogger<BaseController>();
        }

        protected async virtual Task<IActionResult> CreateResponseAsync(Func<Task> func)
        {
            try
            {
                await func();
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "CreateResponseAsync");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected async virtual Task<IActionResult> CreateResponseAsync<T>(Func<Task<T>> func)
        {
            try
            {
                var data = await func();

                return StatusCode((int)HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "CreateResponseAsync<T>");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
