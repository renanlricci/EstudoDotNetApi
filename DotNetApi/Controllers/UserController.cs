using DotNetApi.Domain.Commands.User;
using DotNetApi.Domain.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private ILogger _log;
        public UserController(IMediator mediator, ILoggerFactory loggerFactory) : base(mediator, loggerFactory)
        {
            _log = loggerFactory.CreateLogger<UserController>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return await CreateResponseAsync<IEnumerable<GetAllUserQueryResponse>>(async () => await _mediator.Send(new GetAllUserQuery()));
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(string id)
        {
            return await CreateResponseAsync<GetUserByIdQueryResponse>(async () => await _mediator.Send(new GetUserByIdQuery(id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] AddUserCommand command)
        {
            return await CreateResponseAsync(async () => await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] UpdateUserCommand command)
        {
            command.SetId(id);
            return await CreateResponseAsync(async () => await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return await CreateResponseAsync(async () => await _mediator.Send(new DeleteUserCommand(id)));
        }
    }
}
