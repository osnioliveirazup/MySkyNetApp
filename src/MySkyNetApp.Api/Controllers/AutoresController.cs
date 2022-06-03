using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySkyNetApp.Application.CreateAutor;
using MySkyNetApp.Application.Interfaces.Metrics;
using StackSpot.ErrorHandler;

namespace MySkyNetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly ICounterAutoresCreated _counterAutoresCreated;

        public AutoresController(IMediator mediator, ICounterAutoresCreated counterAutoresCreated)
        {
            _mediator = mediator;
            _counterAutoresCreated = counterAutoresCreated;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateAutorResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAutorCommand command)
        {
            var result = await _mediator.Send(command);
            _counterAutoresCreated.Increment();
            return Ok(result);
        }
    }
}
