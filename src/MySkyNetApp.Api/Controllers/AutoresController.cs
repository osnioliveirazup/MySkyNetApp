using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySkyNetApp.Application.CreateAutor;
using StackSpot.ErrorHandler;

namespace MySkyNetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AutoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateAutorResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateAutorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
