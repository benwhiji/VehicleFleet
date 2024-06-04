using Microsoft.AspNetCore.Mvc;
using MediatR;
using VehicleFleet.Api.Models;
using VehicleFleet.Api.Commands;
using System.Threading.Tasks;

namespace VehicleFleet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RenewLicenseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RenewLicenseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> RenewLicense([FromBody] Vehicle vehicle)
        {
            var command = new RenewLicenseCommand(vehicle);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
