using MediatR;
using PagedList;
using VehicleFleet.Api.Models;

namespace VehicleFleet.Api.Queries;

public class GetVehicleListQuery : IRequest<PagedList<Vehicle>>
{
    public string? VIN { get; }
    public string? LicenseNumber { get; }
    public string? RegistrationPlate { get; }
    public DateTime? LicenseExpiry { get; }
    public string? Model { get; }
    public string? Color { get; }
    public long? Account { get; }
    public int PageNo { get; } = 0;
    public int PageSize { get; } = 0;

    public GetVehicleListQuery(
        string? vin,
        string? licenseNumber,
        string? registrationPlate,
        DateTime? licenseExpiry,
        string? model,
        string? color,
        long? account,
        int pageNo,
        int pageSize)
    {
        VIN = vin;
        LicenseNumber = licenseNumber;
        RegistrationPlate = registrationPlate;
        LicenseExpiry = licenseExpiry;
        Model = model;
        Color = color;
        Account = account;
        PageNo = pageNo;
        PageSize = pageSize;
    }
}