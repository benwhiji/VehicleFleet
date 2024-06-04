using MediatR;
using VehicleFleet.Api.Commands;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Handlers;

public class DepositAmmountHandler : IRequestHandler<DepositAmmountCommand, Account>
{
    private readonly ApiContext _context;
    public DepositAmmountHandler(ApiContext context)
    {
        _context = context;
    }

    public async Task<Account> Handle(DepositAmmountCommand request, CancellationToken cancellationToken)
    {
        var accountToIncrease = await _context.Accounts.FindAsync(request.Account.Id);

        if (accountToIncrease == null)
        {
            return null;
        }

        accountToIncrease.Balance = accountToIncrease.Balance + request.Account.Balance;

        await _context.SaveChangesAsync();

        return accountToIncrease;
    }
}