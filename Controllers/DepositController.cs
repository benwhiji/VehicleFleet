using Microsoft.AspNetCore.Mvc;
using MediatR;
using VehicleFleet.Api.Models;
using VehicleFleet.Api.Commands;

namespace VehicleFleet.Api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class DepositController : ControllerBase
{
    private readonly ApiContext _context;
    private readonly IMediator _mediator;

    public DepositController(ApiContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
    }

    [HttpPut]
    public async Task<ActionResult<Account>> DepositAmmount(Account request)
    {
        var command = new DepositAmmountCommand(request);
        var result = await _mediator.Send(command);
        return result == null ? NotFound() : Ok(result);
    }
}