using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Models;

namespace WebApplication.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpPost("")]
        public ActionResult<Client> CreateClient(
            [FromBody] Client data,
            [FromServices] IClientService service
        )
        {
            return Ok(service.CreateClient(data));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Client>> ListClients()
        {
            return Ok();
        }
    }
}
