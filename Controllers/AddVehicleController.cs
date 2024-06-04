using Microsoft.AspNetCore.Mvc;
using MediatR;
using VehicleFleet.Api.Models;
using VehicleFleet.Api.Commands;
using System.Threading.Tasks;

namespace VehicleFleet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddVehicleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AddVehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewVehicle([FromBody] Vehicle vehicle)
        {
            if (vehicle == null)
            {
                return BadRequest("Vehicle data is null");
            }

            var command = new CreateNewVehicleCommand(vehicle);
            var result = await _mediator.Send(command);
            return result != null ? Ok(result) : NotFound("Vehicle could not be created");
        }
    }
}
