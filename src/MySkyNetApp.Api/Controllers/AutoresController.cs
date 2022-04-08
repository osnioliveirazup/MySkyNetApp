using System.Net;
using Microsoft.AspNetCore.Mvc;
using StackSpot.ErrorHandler;

namespace MySkyNetApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(AutorRequest), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(HttpResponse), (int)HttpStatusCode.BadRequest)]
        public ActionResult<AutorRequest> Create(AutorRequest request)
        {
            return Ok(request);
        }
    }
}
