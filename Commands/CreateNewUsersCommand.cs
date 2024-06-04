using MediatR;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Commands;

public class CreateNewUserCommand : IRequest<User>
{

    public User User { get; set; }

    public CreateNewUserCommand(User user)
    {
        User = user;
    }
}