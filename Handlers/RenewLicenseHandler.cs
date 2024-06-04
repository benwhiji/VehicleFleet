using MediatR;
using VehicleFleet.Api.Commands;
using VehicleFleet.Api.Models;
using VehicleFleet.Api.Exceptions;

namespace VehicleFleet.Api.Handlers;

public class RenewLicenseHandler : IRequestHandler<RenewLicenseCommand, Vehicle>
{
    private readonly ApiContext _context;
    public RenewLicenseHandler(ApiContext context)
    {
        _context = context;
    }

    public async Task<Vehicle> Handle(RenewLicenseCommand request, CancellationToken cancellationToken)
    {
        // Set the price to renew license to 100
        decimal price = 100M;

        // Check account to see if there are enough funds to execute renewal
        var vehicleToRenew = await _context.Vehicles.FindAsync(request.Vehicle.VIN);

        if (vehicleToRenew == null)
        {
            return null;
        }

        var accountToDeduct = await _context.Accounts.FindAsync(vehicleToRenew.AccountForeignKey);

        if (accountToDeduct.Balance < price)
        {
            throw new InsufficientFundsException("Insufficient Funds", accountToDeduct.UserForeignKey);
        }

        accountToDeduct.Balance = accountToDeduct.Balance - price;

        vehicleToRenew.LicenseExpiry = vehicleToRenew.LicenseExpiry.AddYears(1);

        await _context.SaveChangesAsync();

        return vehicleToRenew;
    }
}