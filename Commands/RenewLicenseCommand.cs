using MediatR;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Commands;

public class RenewLicenseCommand : IRequest<Vehicle>
{
    public Vehicle Vehicle { get; set; }
    public RenewLicenseCommand(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
}