using MediatR;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Commands;

public class CreateNewVehicleCommand : IRequest<Vehicle>
{

    public Vehicle Vehicle { get; set; }

    public CreateNewVehicleCommand(Vehicle vehicle)
    {
        Vehicle = vehicle;
    }
}