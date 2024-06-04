using MediatR;
using PagedList;
using Microsoft.EntityFrameworkCore;
using VehicleFleet.Api.Queries;
using VehicleFleet.Api.Models;


namespace VehicleFleet.Api.Handlers;

public class GetVehicleListHandler : IRequestHandler<GetVehicleListQuery, PagedList<Vehicle>>
{
    private readonly ApiContext _context;
    public GetVehicleListHandler(ApiContext context)
    {
        _context = context;
    }

    public async Task<PagedList<Vehicle>> Handle(GetVehicleListQuery request, CancellationToken cancellationToken)
    {
        var returnedVehicles = await _context.Vehicles.ToListAsync();

        if (request.VIN == null && request.LicenseNumber == null && request.RegistrationPlate == null && request.LicenseExpiry == null && request.Model == null && request.Color == null && request.Account == null)
        {
            var pagedAllVehicles = new PagedList<Vehicle>(returnedVehicles.AsQueryable(), request.PageNo == 0 ? 1 : request.PageNo, request.PageSize == 0 ? 3 : request.PageSize);
            return pagedAllVehicles;
        }

        if (request.VIN != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.VIN == request.VIN).ToList();
        }
        
        if (request.LicenseNumber != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.LicenseNumber == request.LicenseNumber).ToList();
        }

        if (request.RegistrationPlate != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.RegistrationPlate == request.RegistrationPlate).ToList();
        }

        if (request.LicenseExpiry != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.LicenseExpiry == request.LicenseExpiry).ToList();
        }

        if (request.Model != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.Model == request.Model).ToList();
        }

        if (request.Color != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.Color == request.Color).ToList();
        }

        if (request.Account != null)
        {
            returnedVehicles = returnedVehicles.Where(x => x.AccountForeignKey == request.Account).ToList();
        }

        if (returnedVehicles == null)
        {
            return null;
        }

        var pagedFilteredVehicles = new PagedList<Vehicle>(returnedVehicles.AsQueryable(), request.PageNo == 0 ? 1 : request.PageNo, request.PageSize == 0 ? 3 : request.PageSize);
        return pagedFilteredVehicles;
    }
}