using Microsoft.AspNetCore.Mvc;
using MediatR;
using VehicleFleet.Api.Models;
using VehicleFleet.Api.Queries;
using System.Threading.Tasks;
using System;
using PagedList;

namespace VehicleFleet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetVehicleListController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GetVehicleListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromQuery] string? vin,
            [FromQuery] string? licenseNumber,
            [FromQuery] string? registrationPlate,
            [FromQuery] DateTime? licenseExpiry,
            [FromQuery] string? model,
            [FromQuery] string? color,
            [FromQuery] long? account,
            [FromQuery] int pageNo = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = new GetVehicleListQuery(
                vin,
                licenseNumber,
                registrationPlate,
                licenseExpiry,
                model,
                color,
                account,
                pageNo,
                pageSize);

            var result = await _mediator.Send(query);
            return result != null ? Ok(result) : NotFound();
        }
    }
}
