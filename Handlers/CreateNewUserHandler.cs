using MediatR;
using VehicleFleet.Api.Commands;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Handlers;

public class CreateNewUserHandler : IRequestHandler<CreateNewUserCommand, User>
{
    private readonly ApiContext _context;
    public CreateNewUserHandler(ApiContext context)
    {
        _context = context;
    }

    public async Task<User> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            IDNumber = request.User.IDNumber,
            FirstName = request.User.FirstName,
            LastName = request.User.LastName,
            Email = request.User.Email,
            Password = request.User.Password,
            Account = new Account{}
        };

        _context.Users.Add(newUser);

        await _context.SaveChangesAsync();

        return newUser;
    }
}