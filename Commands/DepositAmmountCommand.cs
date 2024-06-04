using MediatR;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Commands;

public class DepositAmmountCommand : IRequest<Account>
{
    public Account Account { get; set; }
    public DepositAmmountCommand(Account account)
    {
        Account = account;
    }
}