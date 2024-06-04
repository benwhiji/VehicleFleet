using MediatR;
using VehicleFleet.Api.Commands;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Handlers;

public class CreateNewVehicleHandler : IRequestHandler<CreateNewVehicleCommand, Vehicle>
{
    private readonly ApiContext _context;
    public CreateNewVehicleHandler(ApiContext context)
    {
        _context = context;
    }

    public async Task<Vehicle> Handle(CreateNewVehicleCommand request, CancellationToken cancellationToken)
    {
        var userAccount = await _context.Accounts.FindAsync(request.Vehicle.AccountForeignKey);

        if (userAccount == null)
        {
            return null;
        }

        if (_context.Vehicles.Any(o => o.VIN == request.Vehicle.VIN))
        {
            return null;
        }

        Console.WriteLine(request.Vehicle.LicenseExpiry);

        var newVehicle = new Vehicle
        {
            VIN = request.Vehicle.VIN,
            LicenseNumber = request.Vehicle.LicenseNumber,
            RegistrationPlate = request.Vehicle.RegistrationPlate,
            LicenseExpiry = request.Vehicle.LicenseExpiry,
            Model = request.Vehicle.Model,
            Color = request.Vehicle.Color,
            Account = userAccount,
            AccountForeignKey = userAccount.Id
        };

        _context.Vehicles.Add(newVehicle);

        await _context.SaveChangesAsync();

        return newVehicle;
    }
}